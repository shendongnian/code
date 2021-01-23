    class QuestionBank
    {
        List<QuestionUnit> theQuestionsList = new List<QuestionUnit>();
        
        public IEnumerable<QuestionUnit> Questions { get { return theQuestionsList; } }
        ...
    }
