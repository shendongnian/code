    [MessageContract]
    public class RemoteFileInfo : IDisposable
    {
    
        private string fileName;
        private long length;
        private System.IO.Stream fileByteStream;
    
        public RemoteFileInfo()
        { 
            
        }
    
        [MessageHeader(MustUnderstand = true)]
        public string FileName
        {
            set { this.fileName = value; }
            get { return this.fileName; }
        }
    
        [MessageHeader(MustUnderstand = true)]
        public long Length
        {
            set { this.length = value; }
            get { return this.length; }
        }
    
        [MessageBodyMember(Order = 1)]
        public System.IO.Stream FileByteStream
        {
            set { this.fileByteStream = value; }
            get { return this.fileByteStream; }
        }
    
        [MessageBodyMember(Order = 2)]
        public Header CustomHeader
        {
            set { this.fileName = FileName; this.length = Length; }
            get { return this.CustomHeader; }
        }
        
        public void Dispose()
        {
            if (fileByteStream != null)
            {
                fileByteStream.Close();
                fileByteStream = null;
            }
        }
    }
    
    public class Header
    {
        public string FileName { get; set; }
        public long Length { get; set; }
    }
