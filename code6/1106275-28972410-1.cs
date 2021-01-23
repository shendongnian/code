	// Method:
	private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
	{
		// get new frame
		Bitmap bitmap = eventArgs.Frame;
		// process the frame
		// Put image in picture box
		pictureBox1.Image = (Bitmap)bitmap.Clone();
		if (detector.ProcessFrame(bitmap) > 0.02) << // PROBLEM
		{
			// ring alarm or do something else
		}
	}
