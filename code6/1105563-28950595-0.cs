    class PlatformInvokeTest
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int puts(string c);
        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();
        public static void Main()
        {
            puts("Test");
            _flushall();
        }
    }
