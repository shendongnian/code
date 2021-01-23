    using System.Diagnostics;
    using System.Runtime.InteropServices;
    [DllImport("user32.dll")]
    public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);
    private static void Maximize()
    {
        Process p = Process.GetCurrentProcess();
        ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
    }
