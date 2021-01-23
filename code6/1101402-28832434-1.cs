    private class Course
    {
        public String Name { get; set; }
        public List<Student> EnrolledStudents { get; set; }
        public Course(String name)
        {
           Name = name;
           EnrolledStudents = new List<Student>();
        }
        public override string ToString()
        {
           return Name;
        }
    }
