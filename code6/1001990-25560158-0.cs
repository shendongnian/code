    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WmfPlaceableFileHeader
    {
         public uint key;  // 0x9aC6CDD7
         public ushort hmf;
         public ushort bboxLeft;
         public ushort bboxTop;
         public ushort bboxRight;
         public ushort bboxBottom;
         public ushort inch;
         public uint reserved;
         public ushort checksum;
    }
    
    Win32.WmfPlaceableFileHeader header = new Win32.WmfPlaceableFileHeader();
    const ushorttwips_per_inch = 1440;
    header.key = 0x9aC6CDD7;  // magic number
    header.hmf = 0;
    header.bboxLeft = 0;
    header.bboxRight = width_in_inches * twips_per_inch;
    header.bboxTop = 0;
    header.bboxBottom = height_in_inches * twips_per_inch;
    header.inch = twips_per_inch;
    header.reserved = 0;
    
    // Calculate checksum for first 10 WORDs.
    ushort checksum = 0;
    byte[] header_bytes = StructureToByteArray(header);
    for (int i = 0; i < 10; i++)
         checksum ^= BitConverter.ToUInt16(header_bytes, i * 2);
    header.checksum = checksum;
    
    // Construct the file in-memory.
    header_bytes = StructureToByteArray(header);
    file_contents.Write(header_bytes, 0, header_bytes.Length);
    file_contents.Write(metafile_bytes, 0, metafile_bytes.Length);
