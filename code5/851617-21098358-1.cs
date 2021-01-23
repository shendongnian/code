    // override the OnManipulationDelta method, instead of setting up event procedures
    
    protected override void OnManipulationDelta(ManipulationDeltaRoutedEventArgs args)
    {
    	// All the Image elements have ManipulationMode = All enabled
    	// The other elements on the page have manipulations disabled
    	// therefore the OriginalSource can only be an image, no need to test for null
    	
        var currentImage = args.OriginalSource as Image;
    	var transform = currentImage.RenderTransform as CompositeTransform;
    
    	transform.TranslateX += args.Delta.Translation.X;
    	transform.TranslateY += args.Delta.Translation.Y;
    
    	transform.ScaleX *= args.Delta.Scale;
    	transform.ScaleY *= args.Delta.Scale;
    
    	transform.Rotation += args.Delta.Rotation;
	base.OnManipulationDelta(args);
}
