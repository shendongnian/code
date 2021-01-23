    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
    public TOut[] ConvertArray<TIn, TOut>(TIn[] input) where TIn:struct where TOut:struct
    {
        if (input == null)
            throw new ArgumentNullException("input");
        int sizeTIn   = Marshal.SizeOf(typeof(TIn));
        int sizeTOut  = Marshal.SizeOf(typeof(TOut));
        int sizeBytes = input.Length*sizeTIn;
        if ((sizeBytes % sizeTOut) != 0)
            throw new ArgumentException("Size of input type is not compatible with size of output type.");
        int sizeOut = sizeBytes/sizeTOut;
        var output = new TOut[sizeOut];
        GCHandle inHandle  = GCHandle.Alloc(input,  GCHandleType.Pinned);
        GCHandle outHandle = GCHandle.Alloc(output, GCHandleType.Pinned);
        try
        {
            IntPtr inPtr  = inHandle.AddrOfPinnedObject();
            IntPtr outPtr = outHandle.AddrOfPinnedObject();
            CopyMemory(outPtr, inPtr, (uint)sizeBytes);
        }
        finally
        {
            outHandle.Free();
            inHandle.Free();
        }
        return output;
    }
