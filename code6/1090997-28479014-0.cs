    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsVisible { get; set; }
        public bool IsChecked { get; set; }
    
        public Question()
        {
            SetDefault(0, "", false, false);
        }
        public void Question(int questionId, string text, bool isVisible, bool isChecked)
        { 
            SetDefault(questionId, text, isVisible, isChecked);
        }
    
        private void SetDefault(int questionId, string text, bool isVisible, bool isChecked)
        {
           QuestionId = questionId;
           Text = text;
           IsVisible = isVisible;
           IsChecked = isChecked;
        }
    }
