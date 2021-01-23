    public static CoTaskMemoryHandle CopyToCoTaskMem(this byte[] array)
    {
        var ptr = AllocArrayCoTaskMem(array);
        Marshal.Copy(array, 0, ptr, array.Length);
        return new CoTaskMemoryHandle(ptr);
    }
