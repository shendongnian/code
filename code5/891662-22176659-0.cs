    public class Win32OperatingSystem
    {
        internal ulong BytesToMegaBytes(ulong bytes)
        {
            return bytes / (ulong)1024;
        }
    
        public ulong FreePhysicalMemory()
        {
            return GetProperty("FreePhysicalMemory");
        }
    
        public ulong TotalVirtualMemorySize()
        {
            return GetProperty("TotalVirtualMemorySize");
        }
    
        public ulong FreeVirtualMemory()
        {
            return GetProperty("FreeVirtualMemory");
        }
    
        private ulong GetProperty(string propertyName)
        {
            ManagementObjectSearcher moSearcher = new ManagementObjectSearcher
                ("SELECT " + propertyName + " FROM Win32_OperatingSystem");
            using (var enu = moSearcher.Get().GetEnumerator())
            {
                if (!enu.MoveNext()) return 0;
                return BytesToMegaBytes((ulong)enu.Current[propertyName]);
            }
        }
    }
