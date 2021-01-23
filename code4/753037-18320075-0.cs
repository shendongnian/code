    /// <summary>
    /// A stream reader that allows its current position to be changed. This
    /// is not generally possible for stream readers, because the use buffered
    /// reads. 
    /// This reader can be used only for text content. Theoretically it can 
    /// process any encoding, but was checked only for ANSI and UTF8 If you 
    /// want to use this class with any other encoding, please check it.
    /// </summary>   
    public class PositionableStreamReader : StreamReader
    {
        private long _position;
        public PositionableStreamReader(string fileName, Encoding enc)
            : base(fileName, enc)
        {
            CommonConstruct();
        }
        public PositionableStreamReader(Stream stream, Encoding enc)
            : base(stream, enc)
        {
            CommonConstruct();
        }
        /// <summary>
        /// Encoding can really haven't preamble
        /// </summary>        
        public bool IsPreamble()
        {
            byte[] preamble = this.CurrentEncoding.GetPreamble();
            bool res = true;
            for (int i = 0; i < preamble.Length; i++)
            {
                int dd = base.BaseStream.ReadByte();
                if (preamble[i] != dd)
                {
                    res = false;
                    break;
                }
            }
            Position = 0;
            return res;
        }
        /// <summary>
        /// Use this property to get and set real position in file.
        /// Position in BaseStream can be not right.
        /// </summary>
        public long Position
        {
            get { return _position; }
            set
            {
                ((Stream)base.BaseStream).Seek(value, SeekOrigin.Begin);
                this.DiscardBufferedData();
            }
        }
        public override string ReadLine()
        {
            string line = base.ReadLine();
            if (line != null)
            {
                _position += CurrentEncoding.GetByteCount(line);
            }
            _position += CurrentEncoding.GetByteCount(Environment.NewLine);
            return line;
        }
        private void CommonConstruct()
        {
            //we need to add length of symbol which is in begin of file and describes encoding of file                                    
            if (IsPreamble())
            {
                _position = this.CurrentEncoding.GetPreamble().Length;
            }
        }
    }
