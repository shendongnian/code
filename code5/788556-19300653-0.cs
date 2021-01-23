    [DllImport("dllname", CallingConvention=CallingConvention.Cdecl, EntryPoint="test")]
    private static void Test(
        [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst=1024)] float[] avrSwap,
        out int aviFAIL,
        [In, MarshalAs(UnmanagedType.LPStr)] string accInfile,
        [In, MarshalAs(UnmanagedType.LPStr)] string avcOutname,
        [Out, MarshalAs(UnmanagedType.LPStr)], StringBuilder avcMsg
    );
    //Wrapper that correctly initializes the StringBuilder to its rightful size.
    //It's quite stupid that according to the P/Invoke help, 
    //StringBuilder parameters don't support SizeConst.
    public static void WrapTest(float[] avrSwap, out int aviFAIL, string accInfile, string avcOutname, out string avcMsg)
    {
        StringBuilder sbAvcMsg = new StringBuilder(1024);
        Test(avrSwap, out aviFail, accInfile, avcOutname, sbAvcMsg);
        avcMsg = sbAvcMsg.ToString();
    }
