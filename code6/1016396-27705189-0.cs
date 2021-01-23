	public override void DidRotate (UIInterfaceOrientation fromInterfaceOrientation)
	{
		base.DidRotate (fromInterfaceOrientation);
		AppDelegate.ScreenWidth = this.View.Bounds.Width;
		AppDelegate.ScreenHeight = this.View.Bounds.Height;
		UpdateFrameSize ();
	}
