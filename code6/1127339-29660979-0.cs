        public static bool DoesSerialDeviceExist(string name)
        {
            using (var search = new ManagementObjectSearcher
                ("SELECT * FROM WIN32_SerialPort"))
            {
                string[] portnames = SerialPort.GetPortNames();
                var ports = search.Get().Cast<ManagementBaseObject>().ToList();
                var tList = (from n in portnames
                             join p in ports on n equals p["DeviceID"].ToString()
                             select n + " - " + p["Caption"]).ToList();
                string serial = tList.FirstOrDefault(o => o.Contains(name));
                bool isAvailable = false;
                if (serial != null)
                {
                    isAvailable = true;
                }
                return isAvailable;
            }
        }
