    public class Grade
    {
        public GUID GradeId { get; set; }
        public string GradeTitle { get; set; }
        public virtual ICollection<Grade> EligibleGrades { get; set; }
        public virtual ICollection<Grade> GradesThisIsAnEligibleGradeFor { get; set; }
    }
