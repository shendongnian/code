    public class BoxWriter : TextWriter
    {
        TextBox _textBox;
        public TextBoxWriter (TextBox textBox)
        {
            _textBox = textBox;
        }
        public override void Write(char value)
        {
            base.Write(value);
            _textBox.AppendText(value.ToString());
        }
    }
