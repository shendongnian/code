    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
    
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
    	public int Left;
    	public int Top;
    	public int Right;
    	public int Bottom;
    }
    
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
    
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
    
    public static RECT GetWindowLocationByName(string name)
    {
    	IntPtr handle = FindWindow(Constants.vbNullString, name);
    	RECT result = default(RECT);
    	GetWindowRect(handle, ref result);
    	return result;
    }
    
    public static void Test()
    {
    	dynamic location = GetWindowLocationByName("Untitled - Notepad");
    	Screen result = null;
    
    	foreach (Screen s in Screen.AllScreens) {
    		if (s.WorkingArea.IntersectsWith(new Rectangle(location.Left, location.Top, location.Right - location.Left, location.Bottom - location.Top))) {
    			result = s;
    		}
    	}
    }
