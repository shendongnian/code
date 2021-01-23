        internal static class Native
        {
            [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
            private static unsafe extern void CopyMemory(void *dest, void *src, int count);
        
            private static unsafe byte[] Serialize(TestStruct[] index)
            {
                var buffer = new byte[Marshal.SizeOf(typeof(TestStruct)) * index.Length];
                fixed (void* d = &index[0])
                {
                    fixed (void* s = &buffer[0])
                    {
            	        CopyMemory(d, s, buffer.Length);
                    }
                }
        
                return buffer;
            }
        }
