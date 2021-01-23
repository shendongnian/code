    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct MyStruct
    {
        public int Var1 { get; set; }
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        private char[] _Var2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        private char[] _Var3;
        public int Var4 { get; set; }
        public string Var2 {
            get {
                return new string(_var2);
            }
            set {
                this._var2 = value.ToCharArray();
            }
        }
        public string Var3 {
            get {
                return new string(_var3);
            }
            set {
                this._var3 = value.ToCharArray();
            }
        }
    };
