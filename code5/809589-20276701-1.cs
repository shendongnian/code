	private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	private static extern int GetWindowTextLength(IntPtr hWnd);
	[DllImport("user32.dll")]
	private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
	public static string GetWindowText(IntPtr hWnd)
	{
		int size = GetWindowTextLength(hWnd);
		if (size++ > 0)
		{
			var builder = new StringBuilder(size);
			GetWindowText(hWnd, builder, builder.Capacity);
			return builder.ToString();
		}
		return String.Empty;
	}
	public static IEnumerable<IntPtr> FindWindowsWithText(string titleText)
	{
		IntPtr found = IntPtr.Zero;
		List<IntPtr> windows = new List<IntPtr>();
		EnumWindows(delegate(IntPtr wnd, IntPtr param)
		{
			if (GetWindowText(wnd).Contains(titleText))
			{
				windows.Add(wnd);
			}
			return true;
		},
		            IntPtr.Zero);
		return windows;
    } // closing bracket
