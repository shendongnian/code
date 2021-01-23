    public class MyXmlWriter : XmlWriter
    {
        private readonly XmlWriter writer;
        public MyXmlWriter(XmlWriter writer)
        {
            if (writer == null) throw new ArgumentNullException("writer");
            this.writer = writer;
        }
        // This will not be a polymorphic call
        public new void WriteElementString(string localName, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return;
            this.writer.WriteElementString(localName, value);
        }
        
        // the rest of the XmlWriter methods implemented using Decorator Pattern
        // i.e.
        public override void Close()
        {
            this.writer.Close();
        }
        ...
    }
