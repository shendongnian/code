    Console.WriteLine("Is 64 bit: {0}, IntPtr.Size: {1}", Environment.Is64BitProcess, IntPtr.Size);
    int[][] objects = new int[100000][];
    for (int i = 0; i < objects.Length; i++)
    {
        objects[i] = new int[] { 0 };
    }
    long w1 = Environment.WorkingSet;
    GCHandle[] handles = new GCHandle[objects.Length];
    for (int i = 0; i < handles.Length; i++)
    {
        //handles[i] = new GCHandle(handles);
        //handles[i] = GCHandle.Alloc(objects[i]);
        handles[i] = GCHandle.Alloc(objects[i], GCHandleType.Pinned);
    }
    Console.WriteLine("Allocated");
    long w2 = Environment.WorkingSet;
    Console.WriteLine("Used: {0}, by handle: {1}", w2 - w1, ((double)(w2 - w1)) / handles.Length);
    Console.ReadKey();
