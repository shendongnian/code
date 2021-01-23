	private static void MergeBitmaps(string ImageFore, string ImageBack)
	{
		// Define output polygon and coverage rectangle
		Point[] curvePoints = new Point[] {
			new Point(833, 278), new Point(1876, 525), 
			new Point(1876, 837), new Point(833, 830)
		};
		Rectangle outRect = new Rectangle(833, 278, 1043, 559);
		// Create clipping region from points
		GraphicsPath clipPath = new GraphicsPath();
		clipPath.AddPolygon(curvePoints);
		try
		{
			Bitmap imgB = new Bitmap(ImageBack);
			Bitmap imgF = new Bitmap(ImageFore);
			Bitmap m = new Bitmap(ImageBack);
			System.Drawing.Graphics myGraphic = System.Drawing.Graphics.FromImage(m);
			myGraphic.SmoothingMode = SmoothingMode.HighQuality;
			myGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
			myGraphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
			// Draw foreground image into clipping region
			myGraphic.SetClip(clipPath, CombineMode.Replace);
			myGraphic.DrawImage(imgF, outRect);
			myGraphic.ResetClip();
			myGraphic.Save();
			m.Save(@"new location", System.Drawing.Imaging.ImageFormat.Jpeg);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.StackTrace);
		}
	}
