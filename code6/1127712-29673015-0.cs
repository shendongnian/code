    public static class DataExtensions
    {
        public static Stream GetStream(this IDataRecord record, int ordinal)
        {
            return new DbBinaryFieldStream(record, ordinal);
        }
    
        public static Stream GetStream(this IDataRecord record, string name)
        {
            int i = record.GetOrdinal(name);
            return record.GetStream(i);
        }
        
        private class DbBinaryFieldStream : Stream
        {
            private readonly IDataRecord _record;
            private readonly int _fieldIndex;
            private long _position;
            private long _length = -1;
    
            public DbBinaryFieldStream(IDataRecord record, int fieldIndex)
            {
                _record = record;
                _fieldIndex = fieldIndex;
            }
    
            public override bool CanRead
            {
                get { return true; }
            }
    
            public override bool CanSeek
            {
                get { return true; }
            }
    
            public override bool CanWrite
            {
                get { return false; }
            }
    
            public override void Flush()
            {
                throw new NotSupportedException();
            }
    
            public override long Length
            {
                get
                {
                    if (_length < 0)
                    {
                        _length = _record.GetBytes(_fieldIndex, 0, null, 0, 0);
                    }
                    return _length;
                }
            }
    
            public override long Position
            {
                get
                {
                    return _position;
                }
                set
                {
                    _position = value;
                }
            }
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                long nRead = _record.GetBytes(_fieldIndex, _position, buffer, offset, count);
                _position += nRead;
                return (int)nRead;
            }
    
            public override long Seek(long offset, SeekOrigin origin)
            {
                long newPosition = _position;
                switch (origin)
                {
                    case SeekOrigin.Begin:
                        newPosition = offset;
                        break;
                    case SeekOrigin.Current:
                        newPosition = _position + offset;
                        break;
                    case SeekOrigin.End:
                        newPosition = this.Length - offset;
                        break;
                    default:
                        break;
                }
                if (newPosition < 0)
                    throw new ArgumentOutOfRangeException("offset");
                _position = newPosition;
                return _position;
            }
    
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
        }
    }
