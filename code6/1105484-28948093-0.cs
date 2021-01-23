    public class Question
    {
        public int Assignment { get; set; }
        public string ActualAnswer { get; set; }
        public string SelectedAnswer { get; set; }
        public bool IsCorrect
        {
            get { return String.Equals(ActualAnswer, SelectedAnswer, 
                StringComparison.InvariantCultureIgnoreCase); }
        }
    }
    public class Quiz
    {
        public List<Question> Questions { get; set; }
        public int CalculatedScore
        {
            get { return Questions.Count(q => q.IsCorrect); }
        }
        public DateTime TimeStarted { get; set; }
        public TimeSpan TimeAllowed { get; set; }
        public TimeSpan TimeRemaining
        {
            get { return DateTime.Now - (TimeStarted + TimeAllowed); }
        }
        public TimeSpan TimeElapsed
        {
            get { return DateTime.Now - TimeStarted; }
        }
    }
