     public static long getBytes(string letter)
        {
            ManagementObject disk = new ManagementObject(String.Format("win32_logicaldisk.deviceid=\"{0}:\"", letter));
            disk.Get(); 
            return long.Parse(disk["Size"].ToString());
        }
