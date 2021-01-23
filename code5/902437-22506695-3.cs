    [StructLayout(LayoutKind.Sequential,CharSet = CharSet.Unicode)]
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
