    public class Instructor
    {
        //[Key]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
    public class Course
    {
        //[Key]
        public int id { get; set; }
        [DisplayName("Course")]
        [Required(ErrorMessage = "CSExxx")]
        public string progId { get; set; }
        public string name { get; set; }
        public string semester { get; set; }
        public string description { get; set; }
        public virtual Instructor instructor { get; set; }
    }
