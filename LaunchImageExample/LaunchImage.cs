#if LAUNCHIMAGE

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Threading.Tasks;

public static class LaunchImage
{
	public static async void SayCheese()
	{
		HideStatusBar();

		var window = UIApplication.SharedApplication.KeyWindow;

		while (true)
		{
			HideAllTextViews(window);
			ClearAllTitles(window.RootViewController);
			await Task.Delay(3000);
		}
	}

	private static void HideStatusBar()
	{
		UIView statusBar = (UIView)UIApplication.SharedApplication.ValueForKey(new NSString("statusBar"));
		UIView foregroundView = (UIView)statusBar.ValueForKey(new NSString("foregroundView"));
		foregroundView.Hidden = true;
	}

	private static void HideAllTextViews(UIView views)
	{
		foreach (var subView in views.Subviews)
		{
			if (subView.GetType().GetProperty("Text") != null)
			{
				subView.Hidden = true;
			}

			HideAllTextViews(subView);
		}
	}

	private static void ClearAllTitles(UIViewController viewController)
	{
		foreach (var subController in viewController.ChildViewControllers)
		{
			if (subController.NavigationItem != null)
			{
				subController.NavigationItem.Title = "";
			}

			ClearAllTitles(subController);
		}
	}
}


#endif