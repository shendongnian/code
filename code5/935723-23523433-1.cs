    internal struct MyHeader
    {
        public byte FirstByte;
        // etc
    }
    internal class MyFormat
    {
        private readonly string _fileName;
        private MyFormat(string fileName)
        {
            _fileName = fileName;
        }
        public MyHeader Header { get; private set; }
        public string FileName
        {
            get { return _fileName; }
        }
        public static MyFormat FromFileName(string fileName)
        {
            if (fileName == null) throw new ArgumentNullException("fileName");
            // read the header of your file
            var header = new MyHeader();
            using (var reader = new BinaryReader(File.OpenRead(fileName)))
            {
                byte b1 = reader.ReadByte();
                if (b1 != 0xAA)
                {
                    // return null or throw an exception
                }
                header.FirstByte = b1;
                
                // you can also read block of bytes with a BinaryReader
                var readBytes = reader.ReadBytes(10);
                // etc ... whenever something's wrong return null or throw an exception
            }
            // when you're done reading your header create and return the object
            var myFormat = new MyFormat(fileName);
            myFormat.Header = header;
            // the rest of the object is delivered only when needed, see method below
            return myFormat;
        }
        public object GetBigContent()
        {
            var content = new object();
            // use FileName and Header property to get your big content and return it
            // again, use a BinaryReader with 'using' statement here
            return content;
        }
    }
