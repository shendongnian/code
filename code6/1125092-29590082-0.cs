	[DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
	public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
	public static Bitmap Clone(Bitmap bmp) {
		var oldData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
		var newBmp = new Bitmap(bmp.Width, bmp.Height, oldData.PixelFormat);
		var newData = newBmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
		CopyMemory(newData.Scan0, oldData.Scan0, (uint)(Math.Abs(oldData.Stride) * oldData.Height));
		newBmp.UnlockBits(newData);
		
		bmp.UnlockBits(oldData);
		return newBmp;
	}
