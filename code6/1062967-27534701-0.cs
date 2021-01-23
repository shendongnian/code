    ...
        protected override void Render(HtmlTextWriter writer)
        {
            var stringWriter = new TextWriterDecorator(writer.InnerWriter);
            writer.InnerWriter = stringWriter;
            base.Render(writer);
            var html = stringWriter.GetStringBuilder();
        }
    }
    public class TextWriterDecorator : StringWriter
    {
        readonly TextWriter writer;
        public TextWriterDecorator(TextWriter writer)
        {
            this.writer = writer;
        }
        public override void Write(char value)
        {
            this.writer.Write(value);
            base.Write(value);
        }
        public override void Write(char[] buffer)
        {
            this.writer.Write(buffer);
            base.Write(buffer);
        }
        public override void Write(char[] buffer, int index, int count)
        {
            this.writer.Write(buffer, index, count);
            base.Write(buffer, index, count);
        }
        public override void Write(string format)
        {
            this.writer.Write(format);
            base.Write(format);
        }
    }
