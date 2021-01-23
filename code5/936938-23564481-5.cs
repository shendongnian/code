    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Cam
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string ip;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string login;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string pass;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name;
    }
    class Program
    {
        [DllImport(@"PInvokeTestDll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddCameraStruct(Cam cam);
        static void Main(string[] args)
        {
            Cam cam = new Cam
            {
                ip = "192.168.0.232", 
                login = "admin", 
                pass = "admin", 
                name = "kekekeke"
            };
            AddCameraStruct(cam);
        }
    }
