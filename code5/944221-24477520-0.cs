    // Interface
    [Guid("2B2C1A74-248D-48B0-ACB0-3EE94223BDD3"), Description("ManagerClass interface")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [ComVisible(true)]
    public interface IManagerClass
    {
        [DispId(1), Description("Describes MethodAAA")]
        String MethodAAA(String strValue);
        [DispId(2), Description("Start thread work")]
        String StartThreadWork(String strIn, [MarshalAs(UnmanagedType.FunctionPtr)] ref Action callback);
        [DispId(3), Description("Stop thread work")]
        String StopThreadWork(String strIn);
    }
