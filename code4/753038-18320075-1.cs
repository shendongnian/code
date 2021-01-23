    /// <summary>
    /// A stream reader that allows its current position to be changed. This
    /// is not generally possible for stream readers, because the use buffered
    /// reads. 
    /// This reader can be used only for text content. Theoretically it can 
    /// process any encoding, but was checked only for ANSI and UTF8 If you 
    /// want to use this class with any other encoding, please check it.
    /// NOT SAFE FOR ASYNC WRITES.
    /// </summary>   
    public class PositionableStreamWriter : StreamWriter
    {
        /// <summary>
        /// Out best guess counted position.
        /// </summary>
        private long _position;
        
        /// <summary>
        /// Guards against e.g. calling "Write(char[] buffer, int index, int count)" 
        /// as part of the implementation of "Write(string value)", which would cause
        /// double counting.
        /// </summary>
        private bool _guardRecursion; 
        public PositionableStreamWriter(string fileName, bool append, Encoding enc)
            : base(fileName, append, enc)
        {
            CommonConstruct();
        }
        public PositionableStreamWriter(Stream stream, Encoding enc)
            : base(stream, enc)
        {
            CommonConstruct();
        }
        /// <summary>
        /// Encoding can really haven't preamble
        /// </summary>        
        private bool CheckPreamble(long lengthBeforeFlush)
        {
            byte[] preamble = this.Encoding.GetPreamble();
            if (this.BaseStream.Length >= preamble.Length)
            {
                if (lengthBeforeFlush == 0)
                    return true;
                else // we would love to read, but base stream is write-only.
                    return true; // just assume a preamble is there.
            }
            return false;
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
                this.Flush();
                ((Stream)base.BaseStream).Seek(value, SeekOrigin.Begin);
                _position = value;
            }
        }
        public override void Write(char[] buffer)
        {
            if (buffer != null && !_guardRecursion)
                _position += Encoding.GetByteCount(buffer);
            CallBase(() => base.Write(buffer));
        }
        public override void Write(char[] buffer, int index, int count)
        {
            if (buffer != null && !_guardRecursion)
                _position += Encoding.GetByteCount(buffer, index, count);
            CallBase(() => base.Write(buffer, index, count));
        }
        public override void Write(string value)
        {
            if (value != null && !_guardRecursion)
                _position += Encoding.GetByteCount(value);
            CallBase(() => base.Write(value));
        }
        public override void WriteLine()
        {
            if (!_guardRecursion)
                _position += Encoding.GetByteCount(NewLine);
            CallBase(() => base.WriteLine());
        }
        public override void WriteLine(char[] buffer)
        {
            if (buffer != null)
                _position += Encoding.GetByteCount(buffer) + Encoding.GetByteCount(NewLine);
 	        CallBase(() => base.WriteLine(buffer));
        }
        public override void WriteLine(char[] buffer, int index, int count)
        {
            if (buffer != null)
                _position += Encoding.GetByteCount(buffer, index, count) + Encoding.GetByteCount(NewLine);
 	        CallBase(() => base.WriteLine(buffer, index, count));
        }
        public override void WriteLine(string value)
        {
            if (value != null)
                _position += Encoding.GetByteCount(value) + Encoding.GetByteCount(NewLine);
 	        CallBase(() => base.WriteLine(value));
        }
        private void CallBase(Action callBase)
        {
            if (_guardRecursion == true)
                callBase();
            else
            {
                try
                {
                    _guardRecursion = true;
                    callBase();
                }
                finally
                {
                    _guardRecursion = false;
                }
            }
        }
        private void CommonConstruct()
        {
            var lenghtAtConstruction = BaseStream.Length;
            if (lenghtAtConstruction == 0)
                Flush(); // this should force writing the preamble if a preamble is being written.
            //we need to add length of symbol which is in begin of file and describes encoding of file                                    
            if (CheckPreamble(lenghtAtConstruction))
            {
                _position = this.Encoding.GetPreamble().Length;
            }
        }
    }
