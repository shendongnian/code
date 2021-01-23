	[OutputCache(Duration=86400, VaryByParam="text;maxWidth;maxHeight")]
	public ActionResult RotatedImage(string text, int? maxWidth, int? maxHeight)
	{
		SizeF textSize = text.MeasureString(textFont);
		int width = (maxWidth.HasValue ? Math.Min(maxWidth.Value, (int)textSize.Width) : (int)textSize.Width);
		int height = (maxHeight.HasValue ? Math.Min(maxHeight.Value, (int)textSize.Height) : (int)textSize.Height);
		using (Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
		{
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.TextRenderingHint = TextRenderingHint.AntiAlias;
				g.DrawString(text, textFont, Brushes.Black, zeroPoint, StringFormat.GenericTypographic);
				bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
				using (MemoryStream ms = new MemoryStream())
				{
					bmp.Save(ms, ImageFormat.Png);
					return File(ms.ToArray(), "image/png");
				}
			}
		}
	}
