    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Transaction 
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string pos_id;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string ev_type;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string amount;
        [MarshalAs(UnmanagedType.I1)]
        public bool chip_reader_used;
        [MarshalAs(UnmanagedType.I1)]
        public bool internal_magstripereader_used;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
        public string track2data;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string card_usage_mode;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string receipt_directory;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
        public string additional_info;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string event_number;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string original_filingcode;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string transaction_reasoncode;
    };
