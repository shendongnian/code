    public partial class someKindOfViewController: UIViewController
    {
        private UIView view;
	
    	public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			UpdateGUI ();
		}
    	public override void ViewDidLoad ()
		{
			base.ViewWillAppear ();
			view = new UIView ();
          
            this.View.AddSubView (view);
		}
    	public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
    	{
    		base.DidRotate (fromInterfaceOrientation);
 
    		UpdateGUI ();
    	}
        public void UpdateGUI ()
        {
            view.Frame = new RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height);
        }
    }
