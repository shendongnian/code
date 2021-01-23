        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            internal Rect(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);
        public void DumpWindow(IntPtr hwndSource, string filename)
        {
            Rect rc;
            GetWindowRect(hwndSource, out rc);
            var bmp = new Bitmap(rc.Right - rc.Left, rc.Bottom - rc.Top, PixelFormat.Format32bppArgb);
            using (Graphics gBmp = Graphics.FromImage(bmp))
            {
                IntPtr hdcBmp = gBmp.GetHdc();
                PrintWindow(hwndSource, hdcBmp, 0);
                gBmp.ReleaseHdc(hdcBmp);
            }
            bmp.Save(filename);
        }
