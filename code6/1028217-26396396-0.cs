    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
    
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public List<Course> AllotedCourses { get; set; }
    }
    
    public class Student
    {
        public int EnrollmentNo { get; set; }
        public string StudentName { get; set; }
        public List<Course> EnrolledCourses { get; set; }
    }
