            [DllImport("user32.dll", SetLastError = true)]
            internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "notepad.exe";
            Process process = Process.Start(startInfo);
            process.WaitForInputIdle(); // Wait for interface to load
            MoveWindow(process.MainWindowHandle, 0, 0, 100, 100, true);
