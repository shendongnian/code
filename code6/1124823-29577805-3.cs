    /// <summary>
    /// Transforms an image to black and white.
    /// </summary>
    /// <param name="img">The image.</param>
    /// <returns>The black and white image.</returns>
    public static Image GetBlackAndWhiteImage(Image img)
    {
	Bitmap bmp = new Bitmap(img.Width, img.Height);
	System.Drawing.Imaging.ColorMatrix grayMatrix = new System.Drawing.Imaging.ColorMatrix({
		new float[] {
			0.299f,
			0.299f,
			0.299f,
			0,
			0
		},
		new float[] {
			0.587f,
			0.587f,
			0.587f,
			0,
			0
		},
		new float[] {
			0.114f,
			0.114f,
			0.114f,
			0,
			0
		},
		new float[] {
			0,
			0,
			0,
			1,
			0
		},
		new float[] {
			0,
			0,
			0,
			0,
			1
		}
	});
	using (Graphics g = Graphics.FromImage(bmp)) {
		using (System.Drawing.Imaging.ImageAttributes ia = new System.Drawing.Imaging.ImageAttributes()) {
			ia.SetColorMatrix(grayMatrix);
			ia.SetThreshold(0.5);
			g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
		}
	}
	return bmp;
    }
    
    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //=======================================================
