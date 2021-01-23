    public class Quiz
    {
        public List<Question> Questions { get; set; }
        public Quiz() { Questions = new List<Question>(); }
    }
    public class Question
    {
        public string Question { get; set; }
        public bool Answer { get; set; }
    }
