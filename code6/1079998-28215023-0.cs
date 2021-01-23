    public class PrintText
    {
        public PrintText(string text, Font font) : this(text, font, new StringFormat()) {}
        public PrintText(string text, Font font, StringFormat stringFormat)
        {
            Text = text;
            Font = font;
            StringFormat = stringFormat;
        }
        public string Text { get; set; }
        
        public Font Font { get; set; }
        /// <summary> Default is horizontal string formatting </summary>
        public StringFormat StringFormat { get; set; }
    }
