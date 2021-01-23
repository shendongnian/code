    public struct champ
    {
        public uint mem1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        public byte[] mem2;
        public champ(int x)  { ... }
    }
