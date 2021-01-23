    public class Answer
    {
        public int ID { get; set; }
        
        public string Text { get; set; }
        public int Correct { get; set; }
        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
