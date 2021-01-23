	partial class CustomNavigationController : UINavigationController
	{
		public CustomNavigationController(UIViewController rootViewController) : base(rootViewController)
		{
		}
		public CustomNavigationController (IntPtr handle) : base (handle)
		{
		}
		public override bool ShouldAutorotate ()
		{
			return TopViewController.ShouldAutorotate();
		}
		public override UIInterfaceOrientation PreferredInterfaceOrientationForPresentation ()
		{
			return TopViewController.PreferredInterfaceOrientationForPresentation ();
		}
	}
