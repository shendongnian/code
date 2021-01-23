    [StructLayout(LayoutKind.Sequential,CharSet = CharSet.Unicode)]
    public struct __NIC_STAT
    {
        uint Size;   
        [MarshalAs(UnmanagedType.LPWStr)]        
        public string ptcDeviceName; 
        uint DeviceState;      
        uint DeviceState;      
        uint MediaType;        
        uint MediaState;       
        uint PhysicalMediaType;
        uint LinkSpeed;        
        ulong PacketsSent;
        ulong PacketsReceived;
        uint InitTime;      
        uint ConnectTime;   
        ulong BytesSent;    
        ulong BytesReceived; 
        ulong DirectedBytesReceived;
        ulong DirectedPacketsReceived;
        uint PacketsReceiveErrors;
        uint PacketsSendErrors;
        uint ResetCount;
        uint MediaSenseConnectCount;
        uint MediaSenseDisconnectCount; 
    };
