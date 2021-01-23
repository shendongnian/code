	byte[] imgData;
	using (Bitmap bmp = new Bitmap(100, 100, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
	{
		using (Graphics g = Graphics.FromImage(bmp))
		{
			g.Clear(Color.Transparent);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
			g.FillEllipse(Brushes.Red, 10, 10, 90, 90);
			g.DrawString("Test", SystemFonts.DefaultFont, Brushes.Green, 30, 45);
		}
		using (MemoryStream ms = new MemoryStream())
		{
			bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
			imgData = ms.ToArray();
		}
	}
