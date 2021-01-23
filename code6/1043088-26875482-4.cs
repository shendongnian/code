    public class CourseViewModel
    {
        public IEnumerable<Course_Student> PageData{ get; set; }
    }
    
    public class Course_Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string Course { get; set; }
        public string ClassRoom { get; set; }        
    }
