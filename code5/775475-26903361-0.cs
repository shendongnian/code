		public static Image Fit2PictureBox(this Image image, PictureBox picBox)
		{
			Bitmap bmp = null;
			Graphics g;
			// Scale:
			double scaleY = (double)image.Width / picBox.Width;
			double scaleX = (double)image.Height / picBox.Height;
			double scale = scaleY < scaleX ? scaleX : scaleY;
			// Create new bitmap:
			bmp = new Bitmap(
				(int)((double)image.Width / scale),
				(int)((double)image.Height / scale));
			// Set resolution of the new image:
			bmp.SetResolution(
				image.HorizontalResolution,
				image.VerticalResolution);
			// Create graphics:
			g = Graphics.FromImage(bmp);
			// Set interpolation mode:
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			// Draw the new image:
			g.DrawImage(
				image,
				new Rectangle(			// Ziel
					0, 0,
					bmp.Width, bmp.Height),
				new Rectangle(			// Quelle
					0, 0,
					image.Width, image.Height),
				GraphicsUnit.Pixel);
			// Release the resources of the graphics:
			g.Dispose();
			
			// Release the resources of the origin image:
			image.Dispose();
			return bmp;
		}       
        public static Image Crop(this Image image, Rectangle selection)
		{
			Bitmap bmp = image as Bitmap;
			// Check if it is a bitmap:
			if (bmp == null)
				throw new ArgumentException("Kein gültiges Bild (Bitmap)");
			// Crop the image:
			Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);
			// Release the resources:
			image.Dispose();
			return cropBmp;
		}
 
