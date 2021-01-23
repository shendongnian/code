    [DllImport("coredll.dll")]
    private extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);
    
    [DllImport("coredll.dll")]
    private extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);
    
    
    private struct SYSTEMTIME 
    {
        public ushort wYear;
        public ushort wMonth; 
        public ushort wDayOfWeek; 
        public ushort wDay; 
        public ushort wHour; 
        public ushort wMinute; 
        public ushort wSecond; 
        public ushort wMilliseconds; 
    }
    
    private void GetTime()
    {
        // Call the native GetSystemTime method 
        // with the defined structure.
        SYSTEMTIME stime = new SYSTEMTIME();
        GetSystemTime(ref stime);
    
        // Show the current time.           
        MessageBox.Show("Current Time: "  + 
            stime.wHour.ToString() + ":"
            + stime.wMinute.ToString());
    }
    private void SetTime()
    {
        // Call the native GetSystemTime method 
        // with the defined structure.
        SYSTEMTIME systime = new SYSTEMTIME();
        GetSystemTime(ref systime);
    
        // Set the system clock ahead one hour.
        systime.wHour = (ushort)(systime.wHour + 1 % 24);
        SetSystemTime(ref systime);
        MessageBox.Show("New time: " + systime.wHour.ToString() + ":"
            + systime.wMinute.ToString());
    }
