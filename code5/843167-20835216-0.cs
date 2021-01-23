    using System;
    using System.IO;
    
    namespace WindowsPhoneBugFix
    {
        /// <summary>
        /// Stream wrapper to circumnavigate buggy Stream reading of stream returned by ExternalStorageFile.OpenForReadAsync()
        /// </summary>
        public sealed class ExternalStorageFileWrapper : Stream
        {
            private Stream _stream; // Underlying stream
    
            public ExternalStorageFileWrapper(Stream stream)
            {
                if (stream == null)
                    throw new ArgumentNullException("stream");
    
                _stream = stream;
            }
    
            // Workaround described here - http://stackoverflow.com/a/21538189/250254
            public override long Seek(long offset, SeekOrigin origin)
            {
                ulong uoffset = (ulong)offset;
                ulong fix = ((uoffset & 0xffffffffL) << 32) | ((uoffset & 0xffffffff00000000L) >> 32);
                return _stream.Seek((long)fix, origin);
            }
    
            public override bool CanRead
            {
                get { return _stream.CanRead; }
            }
    
            public override bool CanSeek
            {
                get { return _stream.CanSeek; }
            }
    
            public override bool CanWrite
            {
                get { return _stream.CanWrite; }
            }
    
            public override void Flush()
            {
                _stream.Flush();
            }
    
            public override long Length
            {
                get { return _stream.Length; }
            }
    
            public override long Position
            {
                get
                {
                    return _stream.Position;
                }
                set
                {
                    _stream.Position = value;
                }
            }
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                return _stream.Read(buffer, offset, count);
            }
    
            public override void SetLength(long value)
            {
                _stream.SetLength(value);
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                _stream.Write(buffer, offset, count);
            }
        }
    }
