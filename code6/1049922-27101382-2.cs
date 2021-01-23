    class Program
    {
        static void Main(string[] args)
        {
            int WS_EX_TOPMOST = 0x00000008;
            int GWL_EXSTYLE = -20;
            foreach (Process proc in Process.GetProcesses())
            {
                IntPtr hWnd = proc.MainWindowHandle;
                int res = GetWindowLong(hWnd, GWL_EXSTYLE);
                if ((res & WS_EX_TOPMOST) == WS_EX_TOPMOST)
                {
                    Console.WriteLine("Topmost window found for process " + proc.ProcessName);
                }
            }
        }
    
        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    }
