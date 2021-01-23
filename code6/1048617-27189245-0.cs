    class Driver 
    {
    
     private static readonly GCHandle gHandle;
     static Driver
    {
    // ......
       gHandle = GCHandle.Alloc(DriverEntryPoints.Instance, GCHandleType.Pinned);
    }
    
      [STAThread]
            [DllExport("CreateISCDriverInstance", CallingConvention = CallingConvention.Cdecl)]
            public static int CreateIscDriverInstance([MarshalAs(UnmanagedType.LPWStr)] string mediaTypeStr,
                [MarshalAs(UnmanagedType.LPWStr)] string languageCode,
                [MarshalAs(UnmanagedType.LPWStr)] string connectString,
                [In] ref IscKvParamList datasetParams,
                out IntPtr handle)
    {
    //...
                  handle = GCHandle.ToIntPtr(gHandle);
    //...
    }
    
    }
