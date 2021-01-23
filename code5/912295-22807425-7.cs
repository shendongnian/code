    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct teststruct
    {
        public byte acharacter; // don't use C# char which is 2 bytes wide
        public int anumber; 
        public IntPtr astring;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] anarray;
        public IntPtr conststring;
    }
