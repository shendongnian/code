    class TextSetter
    {
        private string text;
        public TextSetter(string text)
        {
            Text = text;
        }
        public string Text
        {
            get{ return text;}
            set{ text = value.Replace('a', 'b');}
        }
    }
