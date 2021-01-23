    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    struct loginStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=8)]
        public string userName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=8)]
        public string password;
        public loginStruct(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
