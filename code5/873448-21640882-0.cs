    public class MyLabel {
        private string _text;
        public string Text {
            get { return _text; }
            set { _text = value; CursorField = _text.Length; }
        }
        public int CursorField { get; private set; }
    }
