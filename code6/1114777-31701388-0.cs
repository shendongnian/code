    [DllImport("User32.dll")]
        public static extern StatusCode GetDisplayConfigBufferSizes(
            QueryDisplayConfigFlags flags, 
            out int numPathArrayElements,
            out int numModeInfoArrayElements);
    [Flags]
    public enum QueryDisplayConfigFlags : uint
    {
        QDC_ZERO = 0x0,
        QDC_ALL_PATHS = 0x00000001,
        QDC_ONLY_ACTIVE_PATHS = 0x00000002,
        QDC_DATABASE_CURRENT = 0x00000004
    }
    public enum StatusCode : uint
    {
        Success = 0,
        InvalidParameter = 87,
        NotSupported = 50,
        AccessDenied = 5,
        GenFailure = 31,
        BadConfiguration = 1610,
        InSufficientBuffer = 122,
    }
    int numPathArrayElements;
    int numModeInfoArrayElements;
    var status = CCDWrapper.GetDisplayConfigBufferSizes(
                 pathType,
                 out numPathArrayElements,
                 out numModeInfoArrayElements);
    [DllImport("User32.dll")]
        public static extern StatusCode QueryDisplayConfig(
            QueryDisplayConfigFlags flags,
            ref int numPathArrayElements,
            [Out] DISPLAYCONFIG_PATH_INFO[] pathInfoArray,
            ref int modeInfoArrayElements,
            [Out] DisplayConfigModeInfo[] modeInfoArray,
            out DISPLAYCONFIG_TOPOLOGY_ID_Flags topologyId
        );
    [Flags]
    public enum DISPLAYCONFIG_TOPOLOGY_ID_Flags: uint
    {
        DISPLAYCONFIG_TOPOLOGY_ZERO = 0x0,
        DISPLAYCONFIG_TOPOLOGY_INTERNAL = 0x00000001,
        DISPLAYCONFIG_TOPOLOGY_CLONE = 0x00000002,
        DISPLAYCONFIG_TOPOLOGY_EXTEND = 0x00000004,
        DISPLAYCONFIG_TOPOLOGY_EXTERNAL = 0x00000008,
        DISPLAYCONFIG_TOPOLOGY_FORCE_UINT32 = 0xFFFFFFFF
    }
