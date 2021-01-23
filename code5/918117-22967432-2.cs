    [DllImport("BSRobots20.DLL", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint BS_Robots_Connect(
        out int nRobotCount,
        [Out] int[] pnRobotIDS,
        [Out] int[] pnRobotTypes,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1)]
        [Out] bool[] pbRobotReadys
    );
