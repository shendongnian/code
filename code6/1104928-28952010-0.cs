    public class Question
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public int? QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
