	video = new Capture(filename);
	bool reading;
	int nframes = (int)video.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
	nframes++;
	Mat frame;
	Image<Bgr, byte> image;
	int i = 0;
	reading = true;
	while (reading)
	{
		frame = video.QueryFrame();
		if (frame != null)
		{
			image = frame.ToImage<Bgr, byte>();
			mainPic.Image = image.ToBitmap();
			image.Dispose();
			frame.Dispose();
		}
		else
		{
			reading = false;
		}
		i++;
	}
