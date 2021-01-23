    public class Answer {
        private string _text;
        public int AnswerId { get; set; }
        public string Text
        {
            get { return _text; }
            set { _text = Class.cleanQuestion(value); }
        }
    }
