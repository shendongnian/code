    using System.Runtime.InteropServices;
    [StructLayout(LayoutKind.Explicit)]
    struct TestUnion 
    {
        [FieldOffset(0)] 
        public int i;
        [FieldOffset(0)] 
        public double d;
        [FieldOffset(0)] 
        public char c;
        [FieldOffset(0)] 
        public byte b1;
    }
