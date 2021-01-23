    using System;
    using System.Drawing; // add reference to the System.Drawing.dll
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.InteropServices;
    namespace DesktopScreenshot
    {
      class Program
      {
        static void Main(string[] args)
        {
            // get the desktop window handle without the task bar
            // if you only use GetDesktopWindow() as the handle then you get and empty image
            IntPtr desktopHwnd = FindWindowEx(GetDesktopWindow(), IntPtr.Zero, "Progman", "Program Manager");
            // get the desktop dimensions
            // if you don't get the correct values then set it manually
            var rect = new Rectangle();
            GetWindowRect(desktopHwnd, ref rect);
            // saving the screenshot to a bitmap
            var bmp = new Bitmap(rect.Width, rect.Height);
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            IntPtr dc = memoryGraphics.GetHdc();
            PrintWindow(desktopHwnd, dc, 0);
            memoryGraphics.ReleaseHdc(dc);
            
            // and now you can use it as you like
            // let's just save it to the desktop folder as a png file
            string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string screenshotPath = Path.Combine(desktopDir, "desktop.png");
            bmp.Save(screenshotPath, ImageFormat.Png);
        }
        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hdc, uint nFlags);
        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr handle, ref Rectangle rect);
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle); 
      }
    }
