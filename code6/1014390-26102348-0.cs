	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Drawing.Imaging;
	public static class Pixelcounter
	{
		private struct PixeldataARGB
		{
			public byte b;
			public byte g;
			public byte r;
			public byte a;
		}
		private struct PixeldataRGB
		{
			public byte b;
			public byte g;
			public byte r;
		}
		public static IEnumerable<Point> CountOccurences(this Image @this, int r, int g, int b)
		{
			if (r < 0 || g < 0 || b < 0)
				throw new ArgumentException("color values must not be negative");
			if (r > 255 || g > 255 || b > 255)
				throw new ArgumentException("color values must be below 256");
			return CountOccurences(@this, (byte)r, (byte)g, (byte)b);
		}
		public static unsafe IEnumerable<Point> CountOccurences(this Image @this, byte r, byte g, byte b)
		{
			Bitmap bitmap = new Bitmap(@this);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
			PixeldataRGB* pointer = (PixeldataRGB*)bitmapData.Scan0;
			List<Point> pointList = new List<Point>();
			for (int y = 0; y < bitmap.Height; y++)
			{
				for (int x = 0; x < bitmap.Width; x++)
				{
					PixeldataRGB current = *pointer;
					if (current.r == r && current.g == g && current.b == b)
						pointList.Add(new Point(x, y));
					pointer++;
				}
			}
			bitmap.Dispose();
			return pointList;
		}
		public static IEnumerable<Point> CountOccurences(this Image @this, int r, int g, int b, int a)
		{
			if (r < 0 || g < 0 || b < 0 || a < 0)
				throw new ArgumentException("color and alpha values must not be negative");
			if (r > 255 || g > 255 || b > 255 || a > 255)
				throw new ArgumentException("color and alpha values must be below 256");
			return CountOccurences(@this, (byte)r, (byte)g, (byte)b, (byte)a);
		}
		public static unsafe IEnumerable<Point> CountOccurences(this Image @this, byte r, byte g, byte b, byte a)
		{
			Bitmap bitmap = new Bitmap(@this);
			BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			PixeldataARGB* pointer = (PixeldataARGB*)bitmapData.Scan0;
			List<Point> pointList = new List<Point>();
			for (int y = 0; y < bitmap.Height; y++)
			{
				for (int x = 0; x < bitmap.Width; x++)
				{
					PixeldataARGB current = *pointer;
					if (current.r == r && current.g == g && current.b == b && current.a == a)
						pointList.Add(new Point(x, y));
					pointer++;
				}
			}
			bitmap.Dispose();
			return pointList;
		}
	}
