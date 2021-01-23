    [Table("SurveyAnswer")]
    public class SurveyAnswer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Answer { get; set; }
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }
        public virtual SurveyItem SurveyItem { get; set; }
        public virtual SurveyItemOption SurveyItemOption { get; set; }
    }
