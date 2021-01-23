    [DllImport("user32.dll")]
    private static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumWindowsProc ewp, int lParam);
    [DllImport("user32.dll")]
    private static extern bool IsWindowVisible(IntPtr hwnd);
    public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);
    private static void Main(string[] args)
    {
      var collection = new Collection<IntPtr>();
      EnumWindowsProc enumerateHandle = delegate(IntPtr hWnd, int lParam)
      {        
        if (IsWindowVisible(hWnd)) // remove to include hidden windows
          collection.Add(hWnd);       
        
        return true;
      };
      if (EnumDesktopWindows(IntPtr.Zero, enumerateHandle, 0)) {
        foreach (var item in collection) {
          Console.WriteLine(item);
        }
      }
      Console.Read();
    }
