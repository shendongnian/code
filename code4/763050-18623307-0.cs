        internal class FullscreenCheck
        {
            [StructLayout(LayoutKind.Sequential)]
            private struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }
    
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")]
            private static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            private static extern IntPtr GetShellWindow();
            [DllImport("user32.dll", SetLastError = true)]
            private static extern int GetWindowRect(IntPtr hwnd, out RECT rc);
    
            // I hope this handles never changes
            private static IntPtr hndlDesktop = GetDesktopWindow();
            private static IntPtr hndlShell   = GetShellWindow();
    
            public static bool IsFullscreen()
            {
                var hndlForeground = GetForegroundWindow();
                if (hndlForeground == null || hndlForeground == IntPtr.Zero || hndlForeground == hndlDesktop || hndlForeground == hndlShell)
                {
                    return false;
                }
    
                RECT appBounds;
                GetWindowRect(hndlForeground, out appBounds);
                var screenBounds = System.Windows.Forms.Screen.FromHandle(hndlForeground).Bounds;
    
                return ((appBounds.Bottom - appBounds.Top) == screenBounds.Height && (appBounds.Right - appBounds.Left) == screenBounds.Width);
            }
