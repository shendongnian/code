        public static long GetTimestamp() {
            if(IsHighResolution) { 
                long timestamp = 0;
                SafeNativeMethods.QueryPerformanceCounter(out timestamp);
                return timestamp;
            } 
            else {
                return DateTime.UtcNow.Ticks; 
            } 
        }
        [DllImport(ExternDll.Kernel32)]
        [ResourceExposure(ResourceScope.None)]
        public static extern bool QueryPerformanceCounter(out long value); 
