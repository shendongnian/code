    class CourseData
    {
        public string Course { get; set; }
        public int Grade { get; set; }
        public nt CreditHours { get; set; }
        public int GradePoints { get { reutrn Grade * CreditHours; } }
    }
        
