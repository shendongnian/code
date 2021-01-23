    public class CourseStudent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public string Room { get; set; }
    }
    public class CourseStudentViewModel
    {
        public IEnumerable<CourseStudent> CourseStudents { get; set; }
    }
