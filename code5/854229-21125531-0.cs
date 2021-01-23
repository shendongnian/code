    public class ViewC1 : UIViewController
	{
		private int index;
		public ViewC1(int i)
		{
			this.index = i;
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			var button = new UIButton (this.View.Bounds);
			button.SetTitle (string.Format ("Controller {0}", index), UIControlState.Normal);
			this.View.AddSubview (button);
		}
	}
	 
	public class PageViewController : UIPageViewController
	{
		public PageViewController ()
		{
			this.DataSource = new DataSource ();
			this.SetViewControllers (new UIViewController[]{ new ViewC1 (0) }, UIPageViewControllerNavigationDirection.Forward,
				true, null);
		}
	}
	internal class DataSource : UIPageViewControllerDataSource
	{
		private int index;
		private Func<UIViewController>[] viewControllers = new Func<UIViewController>[]
		{
			()=> new ViewC1 (0),
			()=> new ViewC1 (1),
			()=> new ViewC1 (2),
			()=> new ViewC1 (3),
			()=> new ViewC1 (4)
		};
		#region implemented abstract members of UIPageViewControllerDataSource
		public override UIViewController GetPreviousViewController (UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			index = --index < 0 ? viewControllers.Length - 1 : index;
			return viewControllers [index].Invoke();
		}
		public override UIViewController GetNextViewController (UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			index = ++index >= viewControllers.Length ? 0 : index;
			return viewControllers [index].Invoke();
		}
		#endregion
	}
