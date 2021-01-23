    public class CourseViewModel
        {
            public IEnumerable<Course_Student> PageData{ get; set; }
        }
    
    public class Course_Student
        {
    
            public int StudentID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; } 
            public int CourseID { get; set; }
            public string Course { get; set; }
            public string ClassRoom { get; set; }        
    }
