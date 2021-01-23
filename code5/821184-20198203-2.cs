    public class AskQuestion
    {
        public int Id;
        public string Question;
        public string Explanation;
        public List<Answer> Answers = new List<Answer>();
    }
    public class Answer
    {
        public bool Correct = false;
        public string Value;
    }
