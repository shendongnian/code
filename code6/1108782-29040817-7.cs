    class Program
    {
        const uint PAGE_READWRITE = 0x04;
        const uint PAGE_EXECUTE = 0x10;
        const uint MEM_COMMIT = 0x1000;
        const uint MEM_RELEASE = 0x8000;
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool VirtualProtect(IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, out uint lpflOldProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool VirtualFree(IntPtr lpAddress, IntPtr dwSize, uint dwFreeType);
        private delegate int IntReturner();
        static void Main(string[] args)
        {
            List<byte> bodyBuilder = new List<byte>();
            bodyBuilder.Add(0xb8); // MOV EAX,
            bodyBuilder.AddRange(BitConverter.GetBytes(42)); // 42
            bodyBuilder.Add(0xc3);  // RET
            byte[] body = bodyBuilder.ToArray();
            IntPtr buf = IntPtr.Zero;
            try
            {
                // We VirtualAlloc body.Length bytes, with R/W access
                // Note that from what I've read, MEM_RESERVE is useless
                // if the first parameter is IntPtr.Zero
                buf = VirtualAlloc(IntPtr.Zero, (IntPtr)body.Length, MEM_COMMIT, PAGE_READWRITE);
                if (buf == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }
                // Copy our instructions in the buf
                Marshal.Copy(body, 0, buf, body.Length);
                // Change the access of the allocated memory from R/W to Execute
                uint oldProtection;
                bool result = VirtualProtect(buf, (IntPtr)body.Length, PAGE_EXECUTE, out oldProtection);
                if (!result)
                {
                    throw new Win32Exception();
                }
                // Create a delegate to the "function"
                // Sadly we can't use Funct<int>
                var fun = (IntReturner)Marshal.GetDelegateForFunctionPointer(buf, typeof(IntReturner));
                Console.WriteLine(fun());
            }
            finally
            {
                if (buf != IntPtr.Zero)
                {
                    // Free the allocated memory
                    bool result = VirtualFree(buf, IntPtr.Zero, MEM_RELEASE);
                    if (!result)
                    {
                        throw new Win32Exception();
                    }
                }
            }
        }
    }
