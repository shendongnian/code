    public struct __NIC_STAT
    {
        public uint Size;
        public IntPtr ptcDeviceName;
        public uint DeviceState;
        public uint DeviceState;
        public uint MediaType;
        public uint MediaState;
        public uint PhysicalMediaType;
        public uint LinkSpeed;
        public ulong PacketsSent;
        public ulong PacketsReceived;
        public uint InitTime;
        public uint ConnectTime;
        public ulong BytesSent;
        public ulong BytesReceived;
        public ulong DirectedBytesReceived;
        public ulong DirectedPacketsReceived;
        public uint PacketsReceiveErrors;
        public uint PacketsSendErrors;
        public uint ResetCount;
        public uint MediaSenseConnectCount;
        public uint MediaSenseDisconnectCount;
    };
    ....
    var myStruct = new __NIC_STAT();
    myStruct.Size = (15 * 4) + (6 * 8);
    var name = "PCI\\Manixx1\0";
    var nameBytes = Encoding.Unicode.GetBytes(name);
    myStruct.ptcDeviceName = Marshal.AllocHGlobal(nameBytes.Length);
    try
    {
        Marshal.Copy(nameBytes, 0, myStruct.ptcDeviceName, nameBytes.Length);
        // make the IOCTL call, a-la
        NativeMethods.DeviceIoControl(...., ref myStruct, ....);
    }
    finally
    {
        Marshal.FreeHGlobal(myStruct.ptcDeviceName);
    }
