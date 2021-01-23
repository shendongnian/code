    public class CustomXmlWriter : XmlTextWriter
    {
        public CustomXmlWriter(TextWriter wr)
            : base(wr)
        {
        }
        public override void WriteString(string text)
        {
            text = String.Join("",text.Select(Encode));
            base.WriteRaw(text);
        }
        string Encode(char c)
        {
            if (c < 127) return c.ToString();
            return "&#" + ((int)c).ToString() + ";";
        }
    }
