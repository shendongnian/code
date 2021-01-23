        public struct Foo
        {
            public IntPtr x;
        }
        [DllImport(@"Win32Project1.dll", EntryPoint = "MyFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MyFunctionWithIntPtr(IntPtr x);
        [DllImport(@"Win32Project1.dll", EntryPoint = "MyFunction", CallingConvention = CallingConvention.Cdecl)]
        public static extern void MyFunctionWithStruct(Foo x);
        static void Main(string[] args)
        {
            IntPtr j = new IntPtr(10);
            var s = new Foo();
            s.x = new IntPtr(10);
            MyFunctionWithIntPtr(j);
            MyFunctionWithStruct(s);
        }
