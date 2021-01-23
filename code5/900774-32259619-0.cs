    public sealed class StringWriterWithEncoding : System.IO.StringWriter
    {
        private readonly System.Text.Encoding encoding;
        public StringWriterWithEncoding(System.Text.StringBuilder sb) : base(sb)
        {
            this.encoding = System.Text.Encoding.Unicode;
        }
        public StringWriterWithEncoding(System.Text.Encoding encoding)
        {
            this.encoding = encoding;
        }
        public StringWriterWithEncoding(System.Text.StringBuilder sb, System.Text.Encoding encoding) : base(sb)
        {
            this.encoding = encoding;
        }
        public override System.Text.Encoding Encoding
        {
            get { return encoding; }
        }
    }
