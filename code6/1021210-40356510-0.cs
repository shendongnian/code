	public static byte[] GetBGRValues(Bitmap bmp)
	{
		var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
		var bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);
		var rowBytes = bmpData.Width * Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
		var bytes = bmp.Height * rowBytes;
		byte[] rgbValues = new byte[bytes];
		var ptr = bmpData.Scan0;
		for (var i = 0; i < bmp.Height; i++)
		{
			Marshal.Copy(ptr, rgbValues, i * rowBytes, rowBytes);
			ptr += bmpData.Stride;
		}
		bmp.UnlockBits(bmpData);
		return rgbValues;
	}
