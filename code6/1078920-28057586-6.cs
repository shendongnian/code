    public class StudentViewModel
    {
        public List<Question> GeneralQuestions { get; set; }
    }
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionString { get; set; }
        public ICollection<PossibleAnswer> PossibleAnswers { get; set; }
        public int SelectedAnswerId { get; set; }
    }
    public class PossibleAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
    }
