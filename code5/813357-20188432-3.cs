        public struct DisplayInfo
        {
            public string DisplayID;
            public string DisplayName;
            public string EDID;
        }
         [DllImport("user32.dll")]
        static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);
         [DllImport("user32.dll")]
          [return: MarshalAs(UnmanagedType.Bool)]
          static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);
        public static List<DisplayInfo> GetConnectedMonitorInfo()
        {
            var MonitorCollection = new List<DisplayInfo>();
            DISPLAY_DEVICE d = new DISPLAY_DEVICE();
            d.cb = Marshal.SizeOf(d);
            try
            {
                for (uint id = 0; EnumDisplayDevices(null, id, ref d, 0); id++)
                {
                    EnumDisplayDevices(d.DeviceName, 0, ref d, 1);
                    if (string.IsNullOrEmpty(d.DeviceName.ToString()) 
                            && string.IsNullOrEmpty(d.DeviceID.ToString())) continue; 
                    var dispInfo = new DisplayInfo();
                    dispInfo.DisplayID = id.ToString();
                    dispInfo.DisplayName = d.DeviceName.ToString();
                    dispInfo.EDID = d.DeviceID.ToString();
                    
                    if (d.DeviceID.ToString().Contains("ABC4562"))
                    {
                        //Identify Multiple monitor of same series
                        if (string.IsNullOrEmpty(myMonitor.myMonDevName))
                        {
                            myMonitor.myMonDevName = d.DeviceName.ToString();
                        }
                        else
                        {
                            MultipleMonitorFound = true;
                        }
                    }
                        MonitorCollection.Add(dispInfo);
                    d.cb = Marshal.SizeOf(d);
                }
            }
            catch (Exception ex)
            {
               LogError(ex.ToString());
            }
            return MonitorCollection;
        }
