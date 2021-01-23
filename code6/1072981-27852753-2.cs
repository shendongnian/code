    public class Questions
    {
        private List<question> QuestionList = new List<question>();
        public Questions()
        {
            question Q1 = new question("Q", "?", "??", "???", "??"); // just a test question
            QuestionList.Add(Q1); // This generates 4 errors
            
        }
    }
