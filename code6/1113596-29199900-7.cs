    public class CopyStream : Stream
    {
        // This is the stream you want to read your data from
        public Stream ReadStream { get; set; }
        // This is the "logger" stream, where a copy of read data will be put
        public Stream LogStream { get; set; }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int res = ReadStream.Read(buffer, offset, count);
            if (LogStream != null)
            {
                if (res > 0)
                {
                    LogStream.Write(buffer, offset, res);
                }
            }
            return res;
        }
        public override int ReadByte()
        {
            int res = base.ReadByte();
            if (LogStream != null)
            {
                if (res >= 0)
                {
                    LogStream.WriteByte((byte)res);
                }
            }
            return res;
        }
        public override bool CanSeek
        {
            get { return false; }
        }
    }
