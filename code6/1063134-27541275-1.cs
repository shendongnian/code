    int myBool; // Win32's BOOL is actually an 4-byte integral number, 0 or 1
    GCHandle handle = GCHandle.Alloc(myBool, GCHandleType.Pinned);
    try
    {
        IntPtr ptr = handle.AddrOfPinnedObject();
        
        // use ptr
    }
    finally
    {
        handle.Free();
    }
    
