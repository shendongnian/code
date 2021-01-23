    public unsafe sealed class StringArray : IDisposable
    {
        private sbyte** pointer;
        private int count;
    
        public StringArray(string[] array)
        {
            count = array.Length;
    
            pointer = (sbyte**)Marshal.AllocCoTaskMem(count * sizeof(sbyte*));
    
            for (int i = 0; i < count; i++)
            {
                fixed (char* p = array[i])
                {
                    int len = Encoding.ASCII.GetByteCount(array[i]);
                    pointer[i] = (sbyte*)Marshal.AllocCoTaskMem(len + 1); // Zero final byte
    
                    Encoding.ASCII.GetBytes(p, array[i].Length, (byte*)pointer[i], len);
                    pointer[i][len] = 0; // Final zero
                }
            }
        }
    
        ~StringArray()
        {
            Dispose();
        }
    
        public void Dispose()
        {
            if (pointer != null)
            {
                for (int i = 0; i < count; i++)
                {
                    Marshal.FreeCoTaskMem((IntPtr)pointer[i]);
                }
    
                Marshal.FreeCoTaskMem((IntPtr)pointer);
                pointer = null;
                count = 0;
            }
        }
    
        public sbyte** Pointer
        {
            get
            {
                return pointer;
            }
        }
    
        public int Count
        {
            get
            {
                return count;
            }
        }
    }
