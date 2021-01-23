    [DllImport("BSRobots20.DLL", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint BS_Robots_Connect(
        ref int nRobotCount,
        [Out] int[] pnRobotIDS,
        [Out] int[] pnRobotTypes,
        [MarshalAs(UnmanagedType.U1)]
        out bool pbRobotReadys
    );
