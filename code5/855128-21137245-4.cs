    IntPtr[] CreateUnmanagedArrays(double[][] arr)
    {
        IntPtr[] result = new IntPtr[arr.Length];
        for (int i=0; i<arr.Length; i++)
        {
            result[i] = Marshal.AllocCoTaskMem(arr[i].Length*sizeof(double));
            Marshal.Copy(arr[i], 0, result[i], arr[i].Length);
        }
        return result;
    }
    void DestroyUnmanagedArrays(IntPtr[] arr)
    {
        for (int i=0; i<arr.Length; i++)
        {
            Marshal.FreeCoTaskMem(arr[i]);
            arr[i] = IntPtr.Zero;
        }
    }
