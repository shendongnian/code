    public class LoggingStreamWrapper : Stream
    {
        private Stream baseStream;
        private TextWriter twLog;
        private Encoding baseEncoding;
        public LoggingStreamWrapper(Stream baseStream, TextWriter twLog)
            : this(baseStream, twLog, Encoding.UTF8)
        {
        }
        public LoggingStreamWrapper(Stream baseStream, TextWriter twLog, Encoding encoding)
        {
            if (baseStream == null)
                throw new ArgumentNullException("baseStream");
            if (twLog == null)
                throw new ArgumentNullException("twLog");
            this.baseStream = baseStream;
            this.twLog = twLog;
            this.baseEncoding = encoding;
        }
        public override bool CanRead
        {
            get { return baseStream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return baseStream.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return baseStream.CanWrite; }
        }
        public override void Flush()
        {
            baseStream.Flush();
            twLog.WriteLine("Flushed stream");
            twLog.Flush();
        }
        public override long Length
        {
            get { return baseStream.Length; }
        }
        public override long Position
        {
            get { return baseStream.Position; }
            set
            {
                baseStream.Position = value;
                twLog.WriteLine(string.Format("Set position to {0}", value));
                twLog.Flush();
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            var bRead = baseStream.Read(buffer, offset, count);
            if (bRead > 1)
            {
                twLog.WriteLine(string.Format("Read {0} bytes from stream: {1}\r\n{2}", bRead,
                    getText(buffer, offset, bRead),
                    Convert.ToBase64String(buffer, offset, bRead, Base64FormattingOptions.InsertLineBreaks)));
                twLog.Flush();
            }
            else
            {
                twLog.WriteLine(string.Format("Read {0} bytes from stream", bRead));
                twLog.Flush();
            }
            return bRead;
        }
        private string getText(byte[] buffer, int offset, int bRead)
        {
            try
            {
                return baseEncoding.GetString(buffer, offset, bRead);
            }
            catch
            {
                return "{ERROR: Could not convert to text}";
            }
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            var newpos = baseStream.Seek(offset, origin);
            twLog.WriteLine(string.Format("Seeked to {0} relative to {1}.  New offset {2}", offset, origin, newpos));
            twLog.Flush();
            return newpos;
        }
        public override void SetLength(long value)
        {
            baseStream.SetLength(value);
            twLog.WriteLine(string.Format("Set length to {0}", value));
            twLog.Flush();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            baseStream.Write(buffer, offset, count);
            twLog.WriteLine(string.Format("Wrote {0} bytes to stream: {1}\r\n{2}", count,
                getText(buffer, offset, count),
                Convert.ToBase64String(buffer, offset, count, Base64FormattingOptions.InsertLineBreaks)));
            twLog.Flush();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                twLog.Dispose();
                baseStream.Dispose();
            }
        }
    }
