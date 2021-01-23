    [DllImport("BSRobots20.DLL", CallingConvention = CallingConvention.Cdecl)]
    public static extern uint BS_Robots_Connect(
        out int nRobotCount,
        int[] pnRobotIDS,
        int[] pnRobotTypes,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1)]
        bool[] pbRobotReadys
    );
