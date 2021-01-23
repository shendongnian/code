    [StructLayout(LayoutKind.Sequential)]
    public struct Key
    {
          [MarshalAs(UnmanagedType.LPStr)]
          public string key;
          public uint size;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyHolder
    {
          [MarshalAs(UnmanagedType.LPStr)]
          public string name;
          public uint keyCount;
          public IntPtr keys;
    }
