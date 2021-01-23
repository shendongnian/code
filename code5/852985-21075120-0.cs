    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct MyStruct
    {
        public int Var1 { get; set; }
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        private char[] _Var2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        private char[] _Var3;
        public int Var4 { get; set; }
        public string Var2 {
            get {
                // Convert _Var2 from char[] to string here.
            }
            set {
                // Convert value to char[], write to _Var2.
            }
        }
        public string Var3 {
            get {
                // Convert _Var3 from char[] to string here.
            }
            set {
                // Convert value to char[], write to _Var3.
            }
        }
    };
