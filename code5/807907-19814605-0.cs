    public class MyWriter : TextWriter
    {
        private List<string> lines = new List<string>();
        private TextWriter original;
        public MyWriter(TextWriter original)
        {
            this.original = original;
        }
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
        public override void WriteLine(string value)
        {
            lines.Add(value);
            original.WriteLine(value);
        }
        //You need to override other methods also
        public string[] GetLines()
        {
            return lines.ToArray();
        }
    }
