    public class Questions
    {
        List<question> QuestionList = new List<question>();
        
        //Inside Class, cannot call methods, you probably want these 2 in a constructor
        public Questions()
        {
            question Q1 = new question("Q", "?", "??", "???", "??"); // just a test question
            QuestionList.Add(Q1); // This generates 4 errors
        }
    }
