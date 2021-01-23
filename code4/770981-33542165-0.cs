    public class IndentTextXmlWriter : XmlTextWriter
    {
        private int indentLevel;
        private bool isInsideAttribute;
        public IndentTextXmlWriter(TextWriter textWriter): base(textWriter)
        {
        }
        public bool IndentText { get; set; }
        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            isInsideAttribute = true;
            base.WriteStartAttribute(prefix, localName, ns);
        }
        public override void WriteEndAttribute()
        {
            isInsideAttribute = false;
            base.WriteEndAttribute();
        }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            indentLevel++;
            base.WriteStartElement(prefix, localName, ns);
        }
        public override void WriteEndElement()
        {
            indentLevel--;
            base.WriteEndElement();
        }
        public override void WriteString(string text)
        {
            if (String.IsNullOrEmpty(text) || isInsideAttribute || Formatting != Formatting.Indented || !IndentText || XmlSpace == XmlSpace.Preserve)
            {
                base.WriteString(text);
                return;
            }
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string indent = new string(IndentChar, indentLevel * Indentation);
            foreach (string line in lines)
            {
                WriteRaw(Environment.NewLine);
                WriteRaw(indent);
                WriteRaw(line.Trim());
            }
            WriteRaw(Environment.NewLine);
            WriteRaw(new string(IndentChar, (indentLevel - 1) * Indentation));
        }
    }
