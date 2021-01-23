    public class Interest
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
    }
