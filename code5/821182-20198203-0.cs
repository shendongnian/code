    public class AskQuestion
    {
        public int Id;
        public string Question;
        public List<Answer> Answers;
    }
    public class Answer
    {
        public bool Correct = false;
        public string Value;
    }
