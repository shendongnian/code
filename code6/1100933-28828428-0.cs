    // Make wf global and static
    private static WrapFfbCbFunc wf;
    // Make the wrapping callback function static
    public static void  _WrapFfbCbFunc(IntPtr data, IntPtr userData)
    {
        object obj = null;
        if (userData != IntPtr.Zero)
        {
            // Convert userData from pointer to object
            GCHandle handle2 = (GCHandle)userData;
            obj = handle2.Target as object;
        }
        // Call user-defined CB function
        _g_FfbCbFunc(data, obj);
    }
