    private UIImage GetColoredImage(string imageName, Color color)
		{
			UIImage image = UIImage.FromBundle(imageName);
			UIGraphics.BeginImageContext(image.Size);
			CGContext context = UIGraphics.GetCurrentContext();
			context.TranslateCTM(0, image.Size.Height);
			context.ScaleCTM(1.0f, -1.0f);
			var rect = new RectangleF(0, 0, image.Size.Width, image.Size.Height);
			// draw image, (to get transparancy mask)
			context.SetBlendMode(CGBlendMode.Normal);
			context.DrawImage(rect, image.CGImage);
			// draw the color using the sourcein blend mode so its only draw on the non-transparent pixels
			context.SetBlendMode(CGBlendMode.SourceIn);
			context.SetFillColor(color.R / 255f, color.G / 255f, color.B / 255f, 1);
			context.FillRect(rect);
			UIImage coloredImage = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			return coloredImage;
		}
