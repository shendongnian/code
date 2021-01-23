    class Program
    {
        const uint PAGE_EXECUTE_READWRITE = 0x40;
        const uint MEM_COMMIT = 0x1000;
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
        private delegate int IntReturner();
        static void Main(string[] args)
        {
            List<byte> bodyBuilder = new List<byte>();
            bodyBuilder.Add(0xb8); // MOV EAX,
            bodyBuilder.AddRange(BitConverter.GetBytes(42)); // 42
            bodyBuilder.Add(0xc3);  // RET
            byte[] body = bodyBuilder.ToArray();
            IntPtr buf = VirtualAlloc(IntPtr.Zero, (uint)body.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE);
            Marshal.Copy(body, 0, buf, body.Length);
            IntReturner ptr = (IntReturner)Marshal.GetDelegateForFunctionPointer(buf, typeof(IntReturner));
            Console.WriteLine(ptr());
        }
    }
