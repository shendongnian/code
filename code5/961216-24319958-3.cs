    public static byte[] GetBytes<T>(T str)
    {
        int size = Marshal.SizeOf(str);
        var bytes = new byte[size];
        IntPtr ptr = Marshal.AllocHGlobal(size);
        try 
        {
             Marshal.StructureToPtr(str, ptr, true);
             Marshal.Copy(ptr, bytes, 0, size);
             return bytes;
        }
        finally 
        {
             Marshal.FreeHGlobal(ptr);
        }
    }
