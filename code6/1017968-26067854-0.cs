		private Image CreateImage(double[,] data)
		{
			double min = data.Min();
			double max = data.Max();
			double range = max - min;
			byte v;
			Bitmap bm = new Bitmap(data.GetLength(0), data.GetLength(1));
			BitmapData bd = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
			// This is much faster than calling Bitmap.SetPixel() for each pixel.
			unsafe
			{
				byte* ptr = (byte*)bd.Scan0;
				for (int j = 0; j < bd.Height; j++)
				{
					for (int i = 0; i < bd.Width; i++)
					{
						v = (byte)(255 * (data[i, bd.Height - 1 - j] - min) / range);
						ptr[0] = v;
						ptr[1] = v;
						ptr[2] = v;
						ptr[3] = (byte)255;
						ptr += 4;
					}
					ptr += (bd.Stride - (bd.Width * 4));
				}
			}
			bm.UnlockBits(bd);
			return bm;
		}
