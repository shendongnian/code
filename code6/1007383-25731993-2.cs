    public class Utf8StringWriter : StringWriter
    {
        // Use UTF8 encoding but write no BOM to the wire
        public override Encoding Encoding
        {
             get { return new UTF8Encoding(false); } // in real code I'll cache this encoding.
        }
    }
