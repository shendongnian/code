    public static void ToBytes(ulong value, byte[] array, int offset) 
    {
        GCHandle handle = GCHandle.Alloc(value, GCHandleType.Pinned);
        try
        {
            Marshal.Copy(handle.AddrOfPinnedObject(), array, offset, 8);
        }
        finally
        {
            handle.Free();
        }
    }
    
