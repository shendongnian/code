    class TextBoxGroup : UserControl
    {
        public string Text1
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public Color ForeColor1
        {
            get { return textBox1.ForeColor; }
            set { textBox1.ForeColor = value; }
        }
        public string Text2
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public Color ForeColor2
        {
            get { return textBox2.ForeColor; }
            set { textBox2.ForeColor = value; }
        }
        // ...
        public string Text8
        {
            get { return textBox8.Text; }
            set { textBox8.Text = value; }
        }
        public Color ForeColor8
        {
            get { return textBox8.ForeColor; }
            set { textBox8.ForeColor = value; }
        }
    }
