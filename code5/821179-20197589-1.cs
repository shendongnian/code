       public class Question
        {
            public int Id;
            public string QuestionText;
            public List<Answer> Answers;
            public Answer CorrectAnswer;
        }
    
        public class Answer
        {
            public int Id;
            public string Value;
        }
