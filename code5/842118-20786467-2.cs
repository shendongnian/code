    public class QuestionsRepository
    {
        public List<QuestionObj> Questions;
    }
    public class QuestionObj
    {
        public string Question;
        public UInt16 CorrectAnswer;
        public AnswerObj[] Answers;
    }
    public class AnswerObj
    {
        public string Answer;
    }
