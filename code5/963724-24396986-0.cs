    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct VENUS_FORMAT4
    {
        public uint Top;    
        public uint Left;                                                           
        public uint Rows;                                                           
        public uint Columns;                                                        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MAX_CD_ROWS)]
        public uint[] V65Rows;                    
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MAX_CD_COLS_DD2)]
        public uint[] CDCols;                 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.MAX_DD_SECTIONS)]
        public uint[] DDSections;             
    }
