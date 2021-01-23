    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct FATBootSector
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] BS_jmpBoot; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] BS_OEMName; 
        public ushort BPB_BytsPerSec;
        public byte BPB_SecPerClus; 
        public ushort BPB_RsvdSecCnt;
        public byte BPB_NumFATs; 
        public ushort BPB_RootEntCnt;
        public ushort BPB_TotSec16; 
        public byte BPB_Media; 
        public ushort BPB_FATSz16;
        public ushort BPB_SecPerTrk;
        public ushort BPB_NumHeads;
        public uint BPB_HiddSec; 
        public uint BPB_TotSec32; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 474)]
        public byte[] FAT1632Info;
        public ushort Signature;
    }
