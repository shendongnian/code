        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int RegOpenKeyEx(
          UIntPtr hKey,
          string subKey,
          int ulOptions,
          int samDesired,
          out UIntPtr hkResult);
        public static UIntPtr HKEY_LOCAL_MACHINE = new UIntPtr(0x80000002u);
        public static int KEY_WRITE = 0x20006;
        /// <summary>
        /// This method checks write permissions to HKLM\SYSTEM\CurrentControlSet\Services\EventLog which is necessary to create event log source
        /// </summary>
        /// <returns>True if permission to create Event log source is granted, false if not</returns>
        public bool HasCurrentUserEventLogWritePermissions()
        {
            UIntPtr x;
            long err = RegOpenKeyEx(HKEY_LOCAL_MACHINE, @"SYSTEM\CurrentControlSet\Services\EventLog", 0, KEY_WRITE, out x);
            return err == 0;
        }
