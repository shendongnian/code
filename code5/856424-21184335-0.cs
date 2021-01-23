    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("user32.dll", SetLastError=true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hWnd, out W32RECT lpRect);
            [StructLayout(LayoutKind.Sequential)]
            public struct W32RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
            public const uint HWND_BOTTOM = 1;
            static void Main(string[] args)
            {
               IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
               W32RECT rect;
               GetWindowRect(handle , out rect); //to get position and size of your console
               SetWindowPos(handle, IntPtr.Zero, rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top, HWND_BOTTOM);//to set background position of your console with the same size and screen's position
            }
        }
    }
