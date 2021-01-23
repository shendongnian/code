    public interface IRetryable
    {
        int Retries { set; get; }
    }
    public interface IScoreable
    {
        int Score { set; get; }
    }
    public abstract class Question
    {
        private List<string> choices = new List<string>();
        public string QuestionText { set; get; }
        public int SetAnswer { set; get; }
        public void AddChoice(string choiceText)
        {
            choices.Add(choiceText);
        }
    }
    public class QuestionTypeA : Question, IRetryable
    {
        public QuestionTypeA()
        {
            Retries = 1;
        }
        public int Retries { set; get; }
    }
    public class QuestionTypeB : Question, IScoreable
    {
        public QuestionTypeB()
        {
            Score = 0;
        }
        public int Score { set; get; }
    }
