	private byte[] Render(FrameworkElement element)
    {
	    const double SCREEN_DPI = 96.0;
    	const double TARGET_DPI = 300.0;
		// Setup the bounds of the image
		Rect bounds = new Rect(0, 0, element.Width, element.Height);
		element.Measure(bounds.Size);
		element.Arrange(bounds);
		element.UpdateLayout();
		// Create the target bitmap
		RenderTargetBitmap rtb = new RenderTargetBitmap(
            Convert.ToInt32(element.Width / SCREEN_DPI * TARGET_DPI),
            Convert.ToInt32(element.Height / SCREEN_DPI * TARGET_DPI),
            TARGET_DPI, TARGET_DPI, PixelFormats.Pbgra32);
		// Render the visual to the bitmap.
		rtb.Render(element);
        System.Windows.Media.Imaging.BitmapEncoder encoder;
		encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
		encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(rtb));
		var ms = new System.IO.MemoryStream();
		encoder.Save(ms);
		ms.Flush();
		ms.Seek(0, System.IO.SeekOrigin.Begin);
	}
