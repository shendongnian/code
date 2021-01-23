    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DRIVER_INFO_8
    {
        public uint cVersion;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pEnvironment;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pDriverPath;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pDataFile;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pConfigFile;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pHelpFile;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pDependentFiles;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pMonitorName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pDefaultDataType;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszzPreviousNames;
        FILETIME ftDriverDate;
        UInt64 dwlDriverVersion;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszMfgName;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszOEMUrl;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszHardwareID;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszProvider;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszPrintProcessor;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszVendorSetup;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszzColorProfiles;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszInfPath;
        uint dwPrinterDriverAttributes;
        [MarshalAs(UnmanagedType.LPTStr)]
        public string pszzCoreDriverDependencies;
        FILETIME ftMinInboxDriverVerDate;
        UInt64 dwlMinInboxDriverVerVersion;
    }
