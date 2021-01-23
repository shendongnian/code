    public static void ShowAndActivate(this Window window)
    {
      if (window == null) {
        return;
      }
      var hwnd = new WindowInteropHelper(window).Handle;
      ActivateWindowHandle(hwnd);
    }
    
    /// <summary>
    /// Activates and sets focus to the Window Object
    /// </summary>
    public static void ActivateWindowHandle(IntPtr hWnd)
    {
      var threadId1 = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
      var threadId2 = GetWindowThreadProcessId(hWnd, IntPtr.Zero);
      
      if (threadId1 != threadId2) {
        AttachThreadInput(threadId1, threadId2, 1);
        SetForegroundWindow(hWnd);
        AttachThreadInput(threadId1, threadId2, 0);
      } else {
        SetForegroundWindow(hWnd);
      }
    
      if (IsIconic(hWnd)) {
        ShowWindowAsync(hWnd, ShowWindowCommands.Restore);
      } else {
        ShowWindowAsync(hWnd, ShowWindowCommands.Show);
      }
    }
    
    [DllImport("user32.dll")]
    public static extern bool IsIconic(IntPtr hWnd);
    
    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();
    
    [DllImport("user32.dll")]
    public static extern IntPtr AttachThreadInput(IntPtr idAttach, IntPtr idAttachTo, int fAttach);
    
    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
    
    [DllImport("user32.dll")]
    public static extern bool ShowWindowAsync(IntPtr hWnd, ShowWindowCommands cmdShow);
    
    [DllImport("user32.dll")]
    public static extern int SetForegroundWindow(IntPtr hWnd);
    
    public enum ShowWindowCommands : int
    {
      /// <summary>
      /// Hides the window and activates another window.
      /// </summary>
      Hide = 0,
      /// <summary>
      /// Activates and displays a window. If the window is minimized or 
      /// maximized, the system restores it to its original size and position.
      /// An application should specify this flag when displaying the window 
      /// for the first time.
      /// </summary>
      Normal = 1,
      /// <summary>
      /// Activates the window and displays it as a minimized window.
      /// </summary>
      ShowMinimized = 2,
      /// <summary>
      /// Maximizes the specified window.
      /// </summary>
      Maximize = 3, // is this the right value?
      /// <summary>
      /// Activates the window and displays it as a maximized window.
      /// </summary>       
      ShowMaximized = 3,
      /// <summary>
      /// Displays a window in its most recent size and position. This value 
      /// is similar to <see cref="Win32.ShowWindowCommand.Normal"/>, except 
      /// the window is not activated.
      /// </summary>
      ShowNoActivate = 4,
      /// <summary>
      /// Activates the window and displays it in its current size and position. 
      /// </summary>
      Show = 5,
      /// <summary>
      /// Minimizes the specified window and activates the next top-level 
      /// window in the Z order.
      /// </summary>
      Minimize = 6,
      /// <summary>
      /// Displays the window as a minimized window. This value is similar to
      /// <see cref="Win32.ShowWindowCommand.ShowMinimized"/>, except the 
      /// window is not activated.
      /// </summary>
      ShowMinNoActive = 7,
      /// <summary>
      /// Displays the window in its current size and position. This value is 
      /// similar to <see cref="Win32.ShowWindowCommand.Show"/>, except the 
      /// window is not activated.
      /// </summary>
      ShowNA = 8,
      /// <summary>
      /// Activates and displays the window. If the window is minimized or 
      /// maximized, the system restores it to its original size and position. 
      /// An application should specify this flag when restoring a minimized window.
      /// </summary>
      Restore = 9,
      /// <summary>
      /// Sets the show state based on the SW_* value specified in the 
      /// STARTUPINFO structure passed to the CreateProcess function by the 
      /// program that started the application.
      /// </summary>
      ShowDefault = 10,
      /// <summary>
      ///  <b>Windows 2000/XP:</b> Minimizes a window, even if the thread 
      /// that owns the window is not responding. This flag should only be 
      /// used when minimizing windows from a different thread.
      /// </summary>
      ForceMinimize = 11
    }
