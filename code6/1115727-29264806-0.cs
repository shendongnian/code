    public bool ProccesIsRunningNotMinimized(string exeName)
    {
    	Process[] processes = Process.GetProcesses();
    	foreach (Process p in processes)
    	{
    		if (p.ProcessName.ToLower() == exeName.ToLower())
    		{
    			var placement = GetPlacement(p.MainWindowHandle);
    			if (placement.showCmd.ToString().ToLower() != "minimized" && placement.showCmd.ToString().ToLower() != "hide") 
    			return true;
    		}
    
    	}
    	return false;
    
    
    }
    
    // Get the placement of the target process
    private static WINDOWPLACEMENT GetPlacement(IntPtr hwnd)
    {
    	WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
    	placement.length = Marshal.SizeOf(placement);
    	GetWindowPlacement(hwnd, ref placement);
    	return placement;
    }
    
    //Exposes the function of Windows API
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool GetWindowPlacement(
    	IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
    
    
    //Create a struct to receive the data
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    internal struct WINDOWPLACEMENT
    {
    	public int length;
    	public int flags;
    	public ShowWindowCommands showCmd;
    	public System.Drawing.Point ptMinPosition;
    	public System.Drawing.Point ptMaxPosition;
    	public System.Drawing.Rectangle rcNormalPosition;
    }
    
    internal enum ShowWindowCommands : int
    {
    	Hide = 0,
    	Normal = 1,
    	Minimized = 2,
    	Maximized = 3,
    }
