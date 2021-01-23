    private static BitmapSource CopyScreen()
		{
			var left = Screen.AllScreens.Min(screen => screen.Bounds.X);
			var top = Screen.AllScreens.Min(screen => screen.Bounds.Y);
			var right = Screen.AllScreens.Max(screen => screen.Bounds.X + screen.Bounds.Width);
			var bottom = Screen.AllScreens.Max(screen => screen.Bounds.Y + screen.Bounds.Height);
			var width = right - left;
			var height = bottom - top;
			using (var screenBmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
			{
				using (var bmpGraphics = Graphics.FromImage(screenBmp))
				{
					bmpGraphics.CopyFromScreen(left, top, 0, 0, new System.Drawing.Size(width, height));
					return Imaging.CreateBitmapSourceFromHBitmap(
						screenBmp.GetHbitmap(),
						IntPtr.Zero,
						Int32Rect.Empty,
						BitmapSizeOptions.FromEmptyOptions());
				}
			}
		}
