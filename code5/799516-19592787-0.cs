    static object Clone(object input)
    {
        IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(input));
        try
        {
            Marshal.StructureToPtr(input, p, false);
            return Marshal.PtrToStructure(p, input.GetType());
        }
        finally
        {
            Marshal.FreeHGlobal(p);
        }
    }
