     #region For getting the hadnle and min/max operation
            private const int SW_Minimize  = 6;
            private const int SW_Normal    = 1;
           
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            private static WINDOWPLACEMENT GetPlacement(IntPtr hwnd)
            {
                WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
                placement.length = Marshal.SizeOf(placement);
                GetWindowPlacement(hwnd, ref placement);
                return placement;
            }
    
            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool GetWindowPlacement(
                IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
    
            [Serializable]
            [StructLayout(LayoutKind.Sequential)]
            internal struct WINDOWPLACEMENT
            {
                public int length;
                public int flags;
                public ShowWindowCommands showCmd;
                public System.Drawing.Point ptMinPosition;
                public System.Drawing.Point ptMaxPosition;
                public System.Drawing.Rectangle rcNormalPosition;
            }
    
            internal enum ShowWindowCommands : int
            {
                Hide = 0,
                Normal = 1,
                Minimized = 2,
                Maximized = 3,
            }
            #endregion
    
    
     var processes = Process.GetProcessesByName("MyWinformApp");
                    if (processes.Length == 0)
                    {
                        Process.Start("MyWinformApp.exe");
                    }
                    else 
                    {
                        IntPtr handle = processes[0].MainWindowHandle;
                        var placement = GetPlacement(handle);
                        if (String.Equals(placement.showCmd.ToString(), "Minimized")) 
                        {
                            ShowWindow(handle, SW_Normal);
                        }
                        else
                        {
                            ShowWindow(handle, SW_Minimize);
                        }
                        
                    }
