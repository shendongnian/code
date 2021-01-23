    public class SupervisorAnswerQuestion
    {
        public DateTime? Date { set; get; }
        public List<string> Questions { set; get; }
        public List<string> Answers { set; get; }
    }
    public class SupervisorAnswerQuestionViewModel
    {
        public SupervisorAnswerQuestion SupervisorAnswerQuestion {get;set;}
        public string DateFormated 
        {
            get { return SupervisorAnswerQuestion.Date.ToString("yyyy/MM/dd");
        }
    }
