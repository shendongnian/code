    public StringArray(string[] array)
    {
        // space for null terminator at end of array
        int totalLen = (array.Length + 1) * sizeof(sbyte*);
        for (int i = 0; i < array.Length; i++)
        {
            fixed (char* p = array[i])
            {
                int len = Encoding.ASCII.GetByteCount(array[i]);
                totalLen += len + 1; // zero byte at end of string
            }
        }
        pointer = (sbyte**)Marshal.AllocCoTaskMem(totalLen);
        // Memory at the end of the "index" space
        sbyte* pointer2 = (sbyte*)pointer + (array.Length + 1) * sizeof(sbyte*);
        // last element at null
        pointer[array.Length] = null;
        // Now totalLen is only the space for the strings, without the index
        // space
        totalLen -= (array.Length + 1) * sizeof(sbyte*);
        int totalLen2 = 0;
        for (int i = 0; i < array.Length; i++)
        {
            fixed (char* p = array[i])
            {
                pointer[i] = pointer2 + totalLen2;
                totalLen2 += Encoding.ASCII.GetBytes(p, array[i].Length, (byte*)pointer[i], totalLen - totalLen2);
                pointer2[totalLen2] = 0;
                totalLen2 += 1;
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
