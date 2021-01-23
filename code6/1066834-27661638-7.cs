    class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, ref RECT lpRect);
    
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);
    
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
    
        static void Main(string[] args)
        {
    
            RECT rect = new RECT();
            Process[] processes = System.Diagnostics.Process.GetProcessesByName("iexplore");
            Process iexplore = processes.First();
    
            ShowWindow(iexplore.MainWindowHandle, ShowWindowCommands.Restore);
            SetForegroundWindow(iexplore.MainWindowHandle);
            var result = GetWindowRect(iexplore.MainWindowHandle, ref rect);
    
            RectangleF rectF = new RectangleF()
            {
                Location = new PointF(rect.Left, rect.Top),
                Size = new SizeF(rect.Right - rect.Left + 1, rect.Bottom - rect.Top + 1)
            };            
    
            var bmp = new Bitmap((int)rectF.Width, (int)rectF.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen((int)rectF.Left, (int)rectF.Top, 0, 0, new Size((int)rectF.Width, (int)rectF.Height), CopyPixelOperation.SourceCopy);
            bmp.Save(@"C:\temp\screenshot1.jpg", ImageFormat.Jpeg);          
        }      
    }
    
    enum ShowWindowCommands
    {
        Hide = 0,
        Normal = 1,
        ShowMinimized = 2,
        Maximize = 3,
        ShowMaximized = 3,
        ShowNoActivate = 4,
        Show = 5,
        Minimize = 6,
        ShowMinNoActive = 7,
        ShowNA = 8,
        Restore = 9,
        ShowDefault = 10,
        ForceMinimize = 11
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
