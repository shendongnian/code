    /// <summary>
    /// Places the given window in the system-maintained clipboard format listener list.
    /// </summary>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AddClipboardFormatListener(IntPtr hwnd);
     
    /// <summary>
    /// Removes the given window from the system-maintained clipboard format listener list.
    /// </summary>
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool RemoveClipboardFormatListener(IntPtr hwnd);
     
    /// <summary>
    /// Sent when the contents of the clipboard have changed.
    /// </summary>
    private const int WM_CLIPBOARDUPDATE = 0x031D;
