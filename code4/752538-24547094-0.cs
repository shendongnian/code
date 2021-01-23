        public Document FileToByteArray(string _FileName)
        {
            byte[] _Buffer = null;
            try
            {
                // Open file for reading
             FileStream _FileStream = new FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                // attach filestream to binary reader
               BinaryReader _BinaryReader = new BinaryReader(_FileStream);
                // get total byte length of the file
                long _TotalBytes = new FileInfo(_FileName).Length;
                // read entire file into buffer
                _Buffer = _BinaryReader.ReadBytes((Int32)_TotalBytes);
                // close file reader
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();
                Document1 = new Document();
                Document1.DocName = _FileName;
                Document1.DocContent = _Buffer;
                return Document1;
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }
            return Document1;
        }
        public void ByteArraytoFile(string _FileName, byte[] _Buffer)
        {
            if (_FileName != null && _FileName.Length > 0 && _Buffer != null)
            {
                if (!Directory.Exists(Path.GetDirectoryName(_FileName)))
                    Directory.CreateDirectory(Path.GetDirectoryName(_FileName));
                FileStream file = File.Create(_FileName);
                file.Write(_Buffer, 0, _Buffer.Length);
                file.Close();
            }
            
            
        
        }
    
    public static void Main(string[] args)
        {
            Document doc = new Document();
            doc.FileToByteArray("Path to your file");
            doc.Document1.ByteArraytoFile("path to ..to be created file", doc.Document1.DocContent);
        }
    private Document _document;
    public Document Document1
    {
        get { return _document; }
        set { _document = value; }
    }
    public int DocId { get; set; }
    public string DocName { get; set; }
    public byte[] DocContent { get; set; }
    }
