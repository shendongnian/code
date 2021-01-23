        internal struct FATBootSector
        {
            public byte[] BS_jmpBoot; // 0
            public string BS_OEMName; // 3
            public ushort BytesPerSector; // 11
            public byte SectorsPerCluster; // 13
            public ushort ReservedSectors; // 14
            public byte NumberOfFATs; // 16
            public ushort RootEntries; // 17
            public ushort TotalSectors16; // 19
            public byte MediaDescriptor; // 21
            public ushort SectorsPerFAT; // 22
            public ushort SectorsPerTrack; // 24
            public ushort Heads; // 26
            public uint HiddenSectors; // 28
            public uint TotalSectors32; // 32
            public FAT1632Info FAT1632Info;
            public ushort Signature;
            public FATBootSector(IntPtr ptr)
            {
                int i;
                this.BS_jmpBoot = new byte[3];
                for (i = 0; i < 3; i++)
                {
                    this.BS_jmpBoot[i] = Marshal.ReadByte(ptr);
                    ptr = IntPtr.Add(ptr, 1);
                }
                StringBuilder oemInfo = new StringBuilder(8);
                for (i = 0; i < 8; i++)
                {
                    char c = (char)Marshal.ReadByte(ptr);
                    oemInfo.Append(c);
                    ptr = IntPtr.Add(ptr, 1);
                }
                this.BS_OEMName = oemInfo.ToString();
                this.BytesPerSector = (ushort)Marshal.ReadInt16(ptr);
                ptr = IntPtr.Add(ptr, 2);
                this.SectorsPerCluster = Marshal.ReadByte(ptr);
                ptr = IntPtr.Add(ptr, 1);
                this.ReservedSectors = (ushort)Marshal.ReadInt16(ptr);
                ptr = IntPtr.Add(ptr, 2);
                this.NumberOfFATs = Marshal.ReadByte(ptr);
                ptr = IntPtr.Add(ptr, 1);
                this.RootEntries = (ushort)Marshal.ReadInt16(ptr);
                ptr = IntPtr.Add(ptr, 2);
                this.TotalSectors16 = (ushort)Marshal.ReadInt16(ptr);
                ptr = IntPtr.Add(ptr, 2);
                this.MediaDescriptor = Marshal.ReadByte(ptr);
                ptr = IntPtr.Add(ptr, 1);
                this.SectorsPerFAT = (ushort)Marshal.ReadInt16(ptr);
                ptr = IntPtr.Add(ptr, 2);
                this.SectorsPerTrack = (ushort)Marshal.ReadInt16(ptr);
                ptr = IntPtr.Add(ptr, 2);
                this.Heads = (ushort)Marshal.ReadInt16(ptr);
                ptr = IntPtr.Add(ptr, 2);
                this.HiddenSectors = (uint)Marshal.ReadInt32(ptr);
                ptr = IntPtr.Add(ptr, 4);
                this.TotalSectors32 = (uint)Marshal.ReadInt32(ptr);
                ptr = IntPtr.Add(ptr, 4);
                this.FAT1632Info = new PInvoke.FAT1632Info(ptr);
                ptr = IntPtr.Add(ptr, 474);
                this.Signature = (ushort)Marshal.ReadInt16(ptr);
                ptr = IntPtr.Add(ptr, 2);
            }
        }
        [StructLayout(LayoutKind.Sequential, Size=474, Pack=1)]
        internal struct FAT1632Info
        {
            // FAT16
            public byte FAT16_LogicalDriveNumber; // 36
            public byte FAT16_Reserved1; // 37
            public byte FAT16_ExtendedSignature; // 38
            public uint FAT16_PartitionSerialNumber; // 39
            public string FAT16_VolumeName; // 43
            public string FAT16_FSType; // 54
            public byte[] FAT16_Reserved2; // 62
            // FAT32
            public uint FAT32_SectorsPerFAT32; // 36
            public ushort FAT32_ExtFlags; // 40
            public ushort FAT32_FSVer; // 42
            public uint FAT32_RootDirStart; // 44
            public ushort FAT32_FSInfoSector; // 48
            public ushort FAT32_BackupBootSector; // 50
            public byte[] FAT32_Reserved1; // 52
            public byte FAT32_LogicalDriveNumber; // 64
            public byte FAT32_Reserved2; // 65
            public byte FAT32_ExtendedSignature; // 66
            public uint FAT32_PartitionSerialNumber; // 67
            public string FAT32_VolumeName; // 71
            public string FAT32_FSType; // 82
            public byte[] FAT32_Reserved3; // 90
            public FAT1632Info(IntPtr ptr)
            {
                int i;
                IntPtr startPtr = ptr;
                // FAT 16
                this.FAT16_LogicalDriveNumber = Marshal.ReadByte(ptr); // 0
                ptr = IntPtr.Add(ptr, 1);
                this.FAT16_Reserved1 = Marshal.ReadByte(ptr); // 1
                ptr = IntPtr.Add(ptr, 1);
                this.FAT16_ExtendedSignature = Marshal.ReadByte(ptr); // 2
                ptr = IntPtr.Add(ptr, 1);
                this.FAT16_PartitionSerialNumber = (uint)Marshal.ReadInt32(ptr); // 3
                ptr = IntPtr.Add(ptr, 4);
                StringBuilder volName16 = new StringBuilder(11);
                for (i = 0; i < 11; i++)
                {
                    char c = (char)Marshal.ReadByte(ptr);
                    volName16.Append(c);
                    ptr = IntPtr.Add(ptr, 1);
                }
                this.FAT16_VolumeName = volName16.ToString();
                StringBuilder fileSystemType16 = new StringBuilder(8);
                for (i = 0; i < 8; i++)
                {
                    char c = (char)Marshal.ReadByte(ptr);
                    fileSystemType16.Append(c);
                    ptr = IntPtr.Add(ptr, 1);
                }
                this.FAT16_FSType = fileSystemType16.ToString();
                this.FAT16_Reserved2 = new byte[448];
                for (i = 0; i < 448; i++)
                {
                    this.FAT16_Reserved2[i] = Marshal.ReadByte(ptr);
                    ptr = IntPtr.Add(ptr, 1);
                }
                // FAT32
                ptr = startPtr;
                this.FAT32_SectorsPerFAT32 = (uint)Marshal.ReadInt32(ptr); // 36, 4
                ptr = IntPtr.Add(ptr, 4);
                this.FAT32_ExtFlags = (ushort)Marshal.ReadInt16(ptr); // 40, 2
                ptr = IntPtr.Add(ptr, 2);
                this.FAT32_FSVer = (ushort)Marshal.ReadInt16(ptr); // 42, 2
                ptr = IntPtr.Add(ptr, 2);
                this.FAT32_RootDirStart = (uint)Marshal.ReadInt32(ptr); // 44, 4
                ptr = IntPtr.Add(ptr, 4);
                this.FAT32_FSInfoSector = (ushort)Marshal.ReadInt16(ptr); // 48, 2
                ptr = IntPtr.Add(ptr, 2);
                this.FAT32_BackupBootSector = (ushort)Marshal.ReadInt16(ptr); // 50, 2
                ptr = IntPtr.Add(ptr, 2);
                this.FAT32_Reserved1 = new byte[12];  // 52, 12
                for (i=0;i<12;i++) 
                {
                    this.FAT32_Reserved1[i] = Marshal.ReadByte(ptr);
                    ptr = IntPtr.Add(ptr, 1);
                }
                this.FAT32_LogicalDriveNumber = (byte)Marshal.ReadByte(ptr); // 64, 1
                ptr = IntPtr.Add(ptr, 1);
                this.FAT32_Reserved2 = (byte)Marshal.ReadByte(ptr); // 65, 1
                ptr = IntPtr.Add(ptr, 1);
                this.FAT32_ExtendedSignature = (byte)Marshal.ReadByte(ptr); // 66, 1
                ptr = IntPtr.Add(ptr, 1);
                this.FAT32_PartitionSerialNumber = (uint)Marshal.ReadInt32(ptr); // 67, 1
                ptr = IntPtr.Add(ptr, 4);
                StringBuilder volName32 = new StringBuilder(11); // 71, 11
                for (i = 0; i < 11; i++)
                {
                    char c = (char)Marshal.ReadByte(ptr);
                    volName32.Append(c);
                    ptr = IntPtr.Add(ptr, 1);
                }
                this.FAT32_VolumeName = volName32.ToString();
                StringBuilder fileSystemType32 = new StringBuilder(8);   // 82, 8
                for (i = 0; i < 8; i++)
                {
                    char c = (char)Marshal.ReadByte(ptr);
                    fileSystemType32.Append(c);
                    ptr = IntPtr.Add(ptr, 1);
                }
                this.FAT32_FSType = fileSystemType32.ToString();
                this.FAT32_Reserved3 = new byte[420]; // 90, 420
                for (i = 0; i < 420; i++)
                {
                    this.FAT32_Reserved3[i] = Marshal.ReadByte(ptr);
                    ptr = IntPtr.Add(ptr, 1);
                }
            }
        }
