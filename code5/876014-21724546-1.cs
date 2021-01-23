    [StructLayout(LayoutKind.Explicit)]
    struct RAWINPUTUNION
    {
        [FieldOffset(0)]
        public RAWMOUSE mouse;
        [FieldOffset(0)]
        public RAWKEYBOARD keyboard;
        [FieldOffset(0)]
        public RAWHID hid;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct RAWINPUT
    {
        public RAWINPUTHEADER header;       
        public RAWINPUTUNION data;
    }
