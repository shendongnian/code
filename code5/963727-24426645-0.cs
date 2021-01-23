    public struct Points
    {
        int id;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=10)]
        int[] x;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=10)]
        int[] y;
    };
    public struct Shape
    {
        int name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=10)]
        Points[] p;
    };
    public struct GeoShape
    {
        int name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=10)]
        Points[] p;
        int top;
        int left;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=10)]
        int[] v;
    };
