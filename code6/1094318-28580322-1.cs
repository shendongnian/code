    // OMCR_OPTION.COM
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OmcrCom
    {
        public IntPtr Reserved0;
        public uint BaudRate;
        public uint Reserved1;
        public uint Reserved2;
        public uint Reserved3;
        public IntPtr Reserved1;
        public IntPtr Reserved2;
    }
    // OMCR_OPTION.USB
    [StructLayout(LayoutKind.Sequential)]
    public struct OmcrUsb
    {
        public uint Reserved0;
        public uint Reserved1;
        public uint Reserved2;
        public uint Reserved3;
    }
    // OMCR_OPTION
    [StructLayout(LayoutKind.Explicit)]
    public struct OmcrOptions
    {
        [FieldOffset(0)]
        public OmcrCom Com;
        [FieldOffset(0)]
        public OmcrUsb Usb;
    }
    // OMCR
    [StructLayout(LayoutKind.Sequential)]
    public struct OmcrDevice
    {
        public string Device;
        public IntPtr DeviceHandle;
        public IntPtr DevicePointer;
    }
    [DllImport(DllLocation)]
    public static extern IntPtr OmcrOpenDevice(
        string deviceType, 
        ref OmcrOptions options);
