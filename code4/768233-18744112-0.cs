	Image cameraImage=new Image();
	BitmapImage bImage=new BitmapImage();
	
    private void CaptureImageAvailable(object sender, ContentReadyEventArgs e)
    {
		Dispatcher.BeginInvoke(()=>
        {
			bImage.SetSource(e.ImageStream);
			cameraImage.Source = bImage;
		});
    }
