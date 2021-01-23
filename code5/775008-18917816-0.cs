        [StructLayout(LayoutKind.Sequential)]
        public struct CardInfo
        {
            [MarshalAs(UnmanagedType.AnsiBStr, SizeConst = 80)]
            public string cardNumber;
    
            [MarshalAs(UnmanagedType.I1)]
            public byte isExist;
        }
