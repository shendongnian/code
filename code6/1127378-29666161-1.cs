    public class UShortMemoryStream : Stream
    {
        private readonly ushort[] data;
        private int position;
        public UShortMemoryStream(ushort[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            this.data = data;
        }
        private int IntLength
        {
            get
            {
                return data.Length * sizeof(ushort);
            }
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
        }
        public override long Length
        {
            get
            {
                return IntLength;
            }
        }
        public override long Position
        {
            get
            {
                return position;
            }
            set
            {
                if (value < 0 || value > IntLength)
                {
                    throw new ArgumentException();
                }
                position = (int)value;
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException();
            }
            if (offset < 0 || offset > buffer.Length)
            {
                throw new ArgumentException();
            }
            if (count < 0 || count > buffer.Length - offset)
            {
                throw new ArgumentException();
            }
            count = Math.Min(IntLength - position, count);
            // BlockCopy works in **bytes**
            Buffer.BlockCopy(data, position, buffer, offset, count);
            position += count;
            return count;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    if (offset < 0 || offset > IntLength)
                    {
                        throw new ArgumentException();
                    }
                    position = (int)offset;
                    break;
                case SeekOrigin.Current:
                    if (offset < 0)
                    {
                        if (position + offset < 0)
                        {
                            throw new ArgumentException();
                        }
                    }
                    else if (position > IntLength - offset)
                    {
                        throw new ArgumentException();
                    }
                    position += (int)offset;
                    break;
                case SeekOrigin.End:
                    if (offset < 0 || offset > IntLength)
                    {
                        throw new ArgumentException();
                    }
                    position = IntLength - (int)offset;
                    break;
                default:
                    throw new ArgumentException();
            }
            return position;
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
