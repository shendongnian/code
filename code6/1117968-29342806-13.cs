    public StringArray(string[] array)
    {
        int indexLength = (array.Length + 1) * sizeof(sbyte*);
        // space for null terminator at end of array
        int totalLen = indexLength;
        for (int i = 0; i < array.Length; i++)
        {
            fixed (char* p = array[i])
            {
                int len = Encoding.ASCII.GetByteCount(array[i]);
                totalLen += len + 1; // zero byte at end of string
            }
        }
        pointer = (sbyte**)Marshal.AllocCoTaskMem(totalLen);
        // last element at null
        pointer[array.Length] = null;
        // Memory at the end of the "index" space
        sbyte* pointer2 = (sbyte*)pointer + indexLength;
        // remaining space starting from pointer2
        int remainingLen = totalLen - indexLength;
        for (int i = 0; i < array.Length; i++)
        {
            fixed (char* p = array[i])
            {
                pointer[i] = pointer2;
                int len = Encoding.ASCII.GetBytes(p, array[i].Length, (byte*)pointer2, remainingLen);
                pointer2[len] = 0;
                
                len++; // Zero terminator
                pointer2 += len;
                remainingLen -= len;
            }
        }
    }
    public void Dispose()
    {
        if (pointer != null)
        {
            Marshal.FreeCoTaskMem((IntPtr)pointer);
            pointer = null;
            count = 0;
        }
    }
