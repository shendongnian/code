    public StringArray(string[] array)
    {
        pointer = (sbyte**)Marshal.AllocCoTaskMem((array.Length + 1) * sizeof(sbyte*));
        pointer[array.Length] = null;
        for (int i = 0; i < count; i++)
        {
            fixed (char* p = array[i])
            {
                int len = Encoding.ASCII.GetByteCount(array[i]);
                pointer[i] = (sbyte*)Marshal.AllocCoTaskMem(len + 1); // Zero final byte
                Encoding.ASCII.GetBytes(p, len, (byte*)pointer[i], len);
                pointer[i][len] = 0; // Final zero
            }
        }
    }
