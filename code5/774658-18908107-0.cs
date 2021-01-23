    public class Question {
    
        private List<string> answers;
    
        public Question(string text, IEnumerable<string> answers, int answer) {
            this.Text = text;
            this.Answer = answer;
    
            this.answers = new List<string>(answers);
        }
    
        public string Text {
            get;
            private set;
        }
    
        public int Answer {
            get;
            private set;
        }
    
        public IEnumerable<string> Answers {
            get {
                return this.answers;
            }
        }
    
        public string GetAnswer() {
            return this.answers[this.Answer];
        }
    }
