    public static class OpenWithDialog
    {
        [DllImport("shell32.dll", EntryPoint = "SHOpenWithDialog", CharSet = CharSet.Unicode)]
        private static extern int SHOpenWithDialog(IWin32Window parent, ref OpenAsInfo info);
        private struct OpenAsInfo
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string FileName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string FileClass;
            [MarshalAs(UnmanagedType.I4)]
            public OpenAsFlags OpenAsFlags;
        }
        [Flags]
        public enum OpenAsFlags
        {
            None = 0x00,
            AllowRegistration = 0x01,
            RegisterExt = 0x02,
            ExecFile = 0x04,
            ForceRegistration = 0x08,
            HideRegistration = 0x20,
            UrlProtocol = 0x40,
            FileIsUri = 0x80,
        }
        public static int Show(string fileName, IWin32Window parent = null, string fileClass = null, OpenAsFlags openAsFlags = OpenAsFlags.ExecFile)
        {
            var openAsInfo = new OpenAsInfo
                                 {
                                     FileName = fileName,
                                     FileClass = fileClass,
                                     OpenAsFlags = openAsFlags
                                 };
            return SHOpenWithDialog(parent, ref openAsInfo);
        }
    }
