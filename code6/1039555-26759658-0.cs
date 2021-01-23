        [DllImport("C++.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Method1(byte[] str);
        static void Main(string[] args)
        {
            var buffer = new byte[100]; // a C++ char is 1 byte
            Method1(buffer);
            while (true)
            {
                var str = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(str);
                Thread.Sleep(100);
            }
        }
