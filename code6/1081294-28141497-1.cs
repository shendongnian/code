    	Size res = new Size(
		Screen.PrimaryScreen.Bounds.Width,
		Screen.PrimaryScreen.Bounds.Height
	);
	Point ptr = new Point(
		Screen.PrimaryScreen.Bounds.X,
		Screen.PrimaryScreen.Bounds.Y
	);
	using (var bmp = new Bitmap(res.Width, res.Height))
	{
		using (var gfx = Graphics.FromImage(gmp))
		{
			gfx.CopyFromScreen(ptr.X, ptr.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
		}
	}
