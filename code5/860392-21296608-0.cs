	using (Image background = Bitmap.FromFile("tree.png"))
	using (Image masksource = Bitmap.FromFile("mask.png"))
	using (var imgattr = new ImageAttributes())
	{
		// set color key to Lime 
		imgattr.SetColorKey(Color.Lime, Color.Lime);
		// Draw non-lime portions of mask onto original
		using (var g = Graphics.FromImage(background))
		{
			g.DrawImage(
				masksource,
				new Rectangle(0, 0, masksource.Width, masksource.Height),
				0, 0, masksource.Width, masksource.Height,
				GraphicsUnit.Pixel, imgattr
			);
		}
		// Do something with the composited image here...
		background.Save("Composited.png");
	}
