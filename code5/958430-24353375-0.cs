    public class CoverExtractor
    {
        private readonly Stream _stream;
        private readonly BinaryReader _reader;
        private CoverExtractor(Stream mobiFile)
        {
            _stream = mobiFile;
            _reader = new BinaryReader(mobiFile);
        }
        public static Stream ExtractCover(Stream mobiFile)
        {
            return new CoverExtractor(mobiFile).Extract();
        }
        private Stream Extract()
        {
            var firstRecordOffset = ReadPdbRecordOffset(0);
            var mobiHeaderOffset = firstRecordOffset + 16;
            EnsureMagic(mobiHeaderOffset, "MOBI");
            var mobiHeaderLength = ReadUInt32(firstRecordOffset + 20);
            var firstImageRecordIndex = ReadUInt32(firstRecordOffset + 108);
            var exthFlags = ReadUInt32(firstRecordOffset + 128);
            if ((exthFlags & 0x40) == 0)
                return null; // There's no EXTH header
            var exthOffset = mobiHeaderOffset + mobiHeaderLength;
            EnsureMagic(exthOffset, "EXTH");
            var coverRecordOffset = ReadExthRecord(exthOffset, 201);
            if (coverRecordOffset == null)
                return null; // No cover
            var coverOffset = ReadPdbRecordOffset(firstImageRecordIndex + coverRecordOffset.Value);
            var nextRecord = ReadPdbRecordOffset(firstImageRecordIndex + coverRecordOffset.Value + 1);
            _stream.Position = coverOffset;
            return new MemoryStream(_reader.ReadBytes((int)(nextRecord - coverOffset)));
        }
        private long ReadPdbRecordOffset(uint recordIndex)
        {
            return ReadUInt32(78 + 8 * recordIndex);
        }
        private uint? ReadExthRecord(long exthHeaderOffset, int exthRecordType)
        {
            var exthRecordCount = ReadUInt32(exthHeaderOffset + 8);
            for (var i = 0; i < exthRecordCount; ++i)
            {
                var recordType = ReadUInt32();
                var recordLength = ReadUInt32() - 8;
                if (recordType == exthRecordType)
                    return ReadVariableLength(recordLength);
                _reader.ReadBytes((int)recordLength);
            }
            return null;
        }
        private uint ReadVariableLength(uint bytes)
        {
            switch (bytes)
            {
                case 1:
                    return _reader.ReadByte();
                case 2:
                    return ReadUInt16();
                case 4:
                    return ReadUInt32();
                default:
                    throw new NotSupportedException();
            }
        }
        private uint ReadUInt32(long offset)
        {
            _stream.Position = offset;
            return ReadUInt32();
        }
        private ushort ReadUInt16()
        {
            return (ushort)IPAddress.HostToNetworkOrder(_reader.ReadInt16());
        }
        private uint ReadUInt32()
        {
            return (uint)IPAddress.HostToNetworkOrder(_reader.ReadInt32());
        }
        private void EnsureMagic(long offset, string magicString)
        {
            _stream.Position = offset;
            if (Encoding.ASCII.GetString(_reader.ReadBytes(magicString.Length)) != magicString)
                throw new InvalidOperationException("Invalid file format");
        }
    }
