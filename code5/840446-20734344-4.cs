    	private static BitmapSource CaptureScreen(Visual target, double dpiX, double dpiY)
		{
			if (target == null)
			{
				return null;
			}
			Rect bounds = VisualTreeHelper.GetDescendantBounds(target);
			RenderTargetBitmap rtb = new RenderTargetBitmap((int)(bounds.Width * dpiX / 96.0),
															(int)(bounds.Height * dpiY / 96.0),
															dpiX,
															dpiY,
															PixelFormats.Pbgra32);
			DrawingVisual dv = new DrawingVisual();
			using (DrawingContext ctx = dv.RenderOpen())
			{
				VisualBrush vb = new VisualBrush(target);
				ctx.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
			}
			rtb.Render(dv);
			return rtb;
		}
