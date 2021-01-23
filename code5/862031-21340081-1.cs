    [DllImportAttribute("User32.dll")]
    private static extern int FindWindow(String ClassName, String WindowName);
    
    [DllImport("user32.dll")]
    private static extern IntPtr SetForegroundWindow(int hWnd);
    
    public int Activate(int hWnd)
    {
       if (hWnd > 0) {
          SetForegroundWindow(hWnd);
          return hWnd;
       }
       else {
           return -1;
       }
    }
    
    public int GetWindowHwnd(string className, string windowName) {
         int hwnd = 0;
         string cls = className == string.Empty  ? null : className;
         string win = windowName == string.Empty ? null : windowName;
    
         hwnd = FindWindow(cls , win );
         return hwnd;
    }
