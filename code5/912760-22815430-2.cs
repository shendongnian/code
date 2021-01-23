    public partial class Question {
        public string QuestionText { get; set; }
        public Answer SelectedAnswer { get; set; }
        public List<Answer> Answers = new List<Answer>();
    }
