	Bitmap bmp = new Bitmap(Image.Width, Image.Height);
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
			g.DrawImage(Image, new Rectangle(0, 0, Image.Width, Image.Height), 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, ia);
		}
	}
	return bmp;
    }
    
    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //=======================================================
