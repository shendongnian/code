        public static unsafe void ByteArrayToEx(ref Ex  value, int offset, params byte[] bytes)
        {
            // you should add some safely nets here sizeof(Ex) should used for size of struct
            fixed (Ex* obj = &value)
            {
                byte* p = (byte*)obj;
                foreach (var b in bytes)
                {
                    p[offset++] = b;
                }
            }
            // dont return value, it is expensive!
        }
