     class MyLogger : System.IO.TextWriter
        {
            private RichTextBox rtb;
            public MyLogger(RichTextBox rtb) { this.rtb = rtb; }
            public override Encoding Encoding { get { return null; } }
            public override void Write(char value)
            {
                if (value != '\r') rtb.AppendText(new string(value, 1));
            }
        }
