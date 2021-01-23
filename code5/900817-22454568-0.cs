    var value = Resources.MyFont; // it's stored as byte[]
    var fonts = new PrivateFontCollection();
    var memory = IntPtr.Zero;
    try
    {
        memory = Marshal.AllocCoTaskMem(value.Length);
        Marshal.Copy(value, 0, memory, value.Length);
        fonts.AddMemoryFont(memory, value.Length);
    }
    finally
    {
        Marshal.FreeCoTaskMem(memory);
    }
    var font = new Font(fonts.Families[0], 12F); // choose the size
