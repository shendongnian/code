    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct STORAGEDEVICEINFO
    {
        public DWORD cbSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szProfile;
        public DWORD dwDeviceClass;
        public DWORD dwDeviceType;
        public DWORD dwDeviceFlags;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct STOREINFO
    {
        public DWORD cbSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string szDeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szStoreName;
        public DWORD dwDeviceClass;
        public DWORD dwDeviceType;
        public STORAGEDEVICEINFO sdi;
        public DWORD dwDeviceFlags;
        public SECTORNUM snNumSectors;
        public DWORD dwBytesPerSector;
        public SECTORNUM snFreeSectors;
        public SECTORNUM snBiggestPartCreatable;
        public FILETIME ftCreated;
        public FILETIME ftLastModified;
        public DWORD dwAttributes;
        public DWORD dwPartitionCount;
        public DWORD dwMountCount;
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PARTINFO
    {
        public DWORD cbSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szPartitionName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string szFileSys;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string szVolumeName;
        public SECTORNUM snNumSectors;
        public FILETIME ftCreated;
        public FILETIME ftLastModified;
        public DWORD dwAttributes;
        public BYTE bPartType;
    }
