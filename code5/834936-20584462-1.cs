    public class Question
    {
        public string What { get; set; }
        public string[] Answers { get; set; }
        public string Correct { get; set; }
        public bool CheckAnswer(string answer)
        {
            if (answer.Equals(Correct, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
