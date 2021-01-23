    void CopyDemoArrayToDoubleArray(Demo[] demo, out double[] doubles)
    {
        doubles = new double[demo.Length * 2];
        GCHandle gch = GCHandle.Alloc(demo, GCHandleType.Pinned);
        try
        {
            IntPtr demoPtr = gch.AddrOfPinnedObject();
            Marshal.Copy(demoPtr, doubles, 0, doubles.Length);
        }
        finally
        {
            gch.Free();
        }
    }
