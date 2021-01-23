    [StructLayout( LayoutKind.Sequential )]
    internal struct UsnRecordV2: IBinarySerialize
    {
      public uint RecordLength;
      public ushort MajorVersion;
      public ushort MinorVersion;
      public ulong FileReferenceNumber;
      public ulong ParentFileReferenceNumber;
      public long Usn;
      public long TimeStamp;
      public UsnReason Reason;
      public uint SourceInfo;
      public uint SecurityId;
      public uint FileAttributes;
      public ushort FileNameLength;
      public ushort FileNameOffset;
      public string FileName;
      /// <remarks>
      /// Note how the read advances to the FileNameOffset and reads only FileNameLength bytes.
      /// </remarks>
      public void Read( Stream stream )
      {
        var startOfRecord = stream.Position;
        RecordLength = stream.ReadUInt( );
        MajorVersion = stream.ReadUShort( );
        MinorVersion = stream.ReadUShort( );
        FileReferenceNumber = stream.ReadULong( );
        ParentFileReferenceNumber = stream.ReadULong( );
        Usn = stream.ReadLong( );
        TimeStamp = stream.ReadLong( );
        Reason = ( UsnReason ) stream.ReadUInt( );
        SourceInfo = stream.ReadUInt( );
        SecurityId = stream.ReadUInt( );
        FileAttributes = stream.ReadUInt( );
        FileNameLength = stream.ReadUShort( );
        FileNameOffset = stream.ReadUShort( );
        stream.Position = startOfRecord + FileNameOffset;
        FileName = Encoding.Unicode.GetString( stream.ReadBytes( FileNameLength ) );
        stream.Position = startOfRecord + RecordLength;
      }
      /// <summary>We never write instances of this structure</summary>
      void IBinarySerialize.Write( Stream stream )
      {
        throw new NotImplementedException( );
      }
    }
