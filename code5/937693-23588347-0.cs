    public class JsonTextWriterEx : JsonTextWriter
    {
        public string NewLine { get; set; }
        public JsonTextWriterEx (TextWriter textWriter) : base(textWriter)
        {
            NewLine = Environment.NewLine;
        }
        protected override void WriteIndent ()
        {
            if (Formatting == Formatting.Indented) {
                WriteWhitespace(NewLine);
                int currentIndentCount = Top * Indentation;
                for (int i = 0; i < currentIndentCount; i++)
                    WriteIndentSpace();
            }
        }
    }
