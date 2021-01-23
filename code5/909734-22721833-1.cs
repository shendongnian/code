    [StructLayout(LayoutKind.Sequential, Pack = 1)] // Ensure tight packing
    public struct Packet
    {
        public ushort Header;
        public ushort Command;
        public uint Number;
    }
    Packet packet = new Packet { ... };
    byte[] packetData = new byte[Marshal.Sizeof<Packet>()];
    // Using marshaling
    var handle = default(GCHandle);
    try
    {
        handle = GCHandle.Alloc(packetData, GCHandleType.Pinned);
        Marshal.StructureToPtr(packet, handle.AddrOfPinnedObject(), fDeleteOld: false);
    }
    finally
    {
        if (handle.IsAllocated) handle.Free();
    }
    // Using unsafe code (careful, assumes marshaled size == size in memory!)
    unsafe { fixed(byte* packedPtr = packetData) *(Packet*)packedPtr = packet; }
