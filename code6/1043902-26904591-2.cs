    class TextBoxGroup : UserControl
    {
        // Initialized in constructor to be the eight TextBoxes
        private TextBox[] _textboxes;
        public void SetText(int i, string text)
        {
            _textboxes[i].Text = text;
        }
    }
