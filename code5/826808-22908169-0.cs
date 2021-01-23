    [DllImport(@"c:\GDAit.dll")]
    public static extern long TransGeogPt([MarshalAs(UnmanagedType.LPStr)] string sGridFile, long lDirection, double dLat, double dLong, ref double pdLatNew, ref double pdLongNew, ref double pdLatAcc, ref double pdLongAcc);
    
    [DllImport(@"c:\GDAit.dll")]
    public static extern long TransProjPt([MarshalAs(UnmanagedType.LPStr)] string sGridFile, long lDirection, double dLat, double dLong, long lZone, ref double pdLatNew, ref double pdLongNew, ref double pdLatAcc, ref double pdLongAcc);
