    async void RepositionWindow(Process process)
            {
                while ((int)process.MainWindowHandle == 0)
                {
                    await Task.Delay(100);
                }
                IntPtr hWnd = process.MainWindowHandle;
                while (!IsWindowVisible(hWnd))
                {
                    await Task.Delay(100);
                }
                MoveWindow(hWnd, 0, 0, 500, 800, true);
            }
    
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
            static extern bool IsWindowVisible(IntPtr hWnd);
