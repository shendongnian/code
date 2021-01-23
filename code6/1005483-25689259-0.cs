    public class Grade
    {
      
        public int GradeKey { get; set; }
        [Required]
        public string GradeLevel { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
