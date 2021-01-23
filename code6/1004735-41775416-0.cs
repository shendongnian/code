    [StructLayout(LayoutKind.Sequential)]
    public struct EWF_VOLUME_NAME_ENTRY 
    {    
        /// _EWF_VOLUME_NAME_ENTRY*
        public System.IntPtr Next;
    
        /// WCHAR[1]    
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=300)]
        public string Name;
    }
