    public class PListWriter : XmlTextWriter
    {
        public PListWriter(string filename, System.Text.Encoding encoding) : base(filename, encoding) { }
        public PListWriter(Stream filename, System.Text.Encoding encoding) : base(filename, encoding) { }
        public override void WriteDocType(string name = "", string pubid = "", string sysid = "", string subset = "")
        {
            this.WriteRaw("<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">");
        }
    }
