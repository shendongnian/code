    public partial class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public System.DateTime EnrollmentDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:0.###}")]
        public decimal RollNo { get; set; }
    }
