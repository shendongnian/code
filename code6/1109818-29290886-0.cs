	[DllImport("gdi32.dll")]
	public static extern int GetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);
	[DllImport("user32.dll")]
	public static extern IntPtr GetDC(IntPtr hWnd);
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct RAMP
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public UInt16[] Red;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public UInt16[] Green;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public UInt16[] Blue;
	}
	private Color getScreenColor()
	{
		RAMP r = new RAMP();
		GetDeviceGammaRamp(GetDC(IntPtr.Zero), ref r);
		return Color.FromArgb(r.Red[1], r.Green[1], r.Blue[1]);
	}
