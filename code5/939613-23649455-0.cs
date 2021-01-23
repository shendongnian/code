    Demo[] array = new Demo[2];
    array[0] = new Demo {X = 5.6, Y= 6.6};
    array[1] = new Demo {X = 7.6, Y = 8.6};
    GCHandle handle = GCHandle.Alloc(array, GCHandleType.Pinned);
    try
    {
        IntPtr pointer = handle.AddrOfPinnedObject();
        double[] copy = new double[array.Length*2];//This length may be calculated
        Marshal.Copy(pointer, copy, 0, copy.Length);
    }
    finally
    {
        if (handle.IsAllocated)
            handle.Free();
    }
