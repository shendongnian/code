	[System.Runtime.InteropServices.DllImport("kernel32.dll")]
	private static extern void RtlZeroMemory(IntPtr dst, int length);
	
	protected void ClearWriteableBitmap(WriteableBitmap bmp)
	{
		RtlZeroMemory(bmp.BackBuffer, bmp.PixelWidth * bmp.PixelHeight * (bmp.Format.BitsPerPixel / 8));
		bmp.Dispatcher.Invoke(() =>
		{
			bmp.Lock();
			bmp.AddDirtyRect(new Int32Rect(0, 0, bmp.PixelWidth, bmp.PixelHeight));
			bmp.Unlock();
		});
	}
