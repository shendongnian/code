    private const int DataLength = 10;
    private const int StrLen = 16;
    private const int MaxThreatPeaks = 30;
    
    public enum Status { on = 0, off = 1 };
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Result
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = StrLen)] public string name; //!< Up to StrLen-1 char null-terminated name 
        public float location;  
        public Status status;       
    }
    [DllImport("dllname.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "analyzeData@32")] // "@32" is only used in the 32-bit version.
    public static extern void analyzeData(
        double[] data,
        int dataLength, 
        float weight, 
        Status status,
        [MarshalAs(UnmanagedType.LPArray, SizeConst = MaxResults)] ref Result[] results, 
        out int nResults
    );
