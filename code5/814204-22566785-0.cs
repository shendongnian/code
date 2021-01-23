    public class PdfFormatter : MediaTypeFormatter
    {
        #region Constants and Fields
        private const int ChunkSizeMax = 1024 * 10;
        #endregion
        #region Constructors and Destructors
        public PdfFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/pdf"));
        }
        #endregion
        #region Public Methods
        public override bool CanReadType(Type type)
        {
            return false; // can't read any types
        }
        public override bool CanWriteType(Type type)
        {
            return type == typeof(byte[]);
        }
        public override Task WriteToStreamAsync(
            Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            Task t = new Task(() => WritePdfBytes(value, writeStream));
            t.Start();
            return t;
        }
        #endregion
        #region Methods
        private static void WritePdfBytes(object value, Stream writeStream)
        {
            byte[] buffer = value as byte[];
            int offset = 0;
            while (offset < buffer.Length)
            {
                int chunkSize = Math.Min(buffer.Length - offset, ChunkSizeMax);
                writeStream.Write(buffer, offset, chunkSize);
                offset += chunkSize;
            }
        }
        #endregion
    }
