    public class StudentDetails
    {
        public string id { get; set; }
        public string name { get; set; }
        public int percentage { get; set; }
        public string type { get; set; }
    }
    
    public class Student
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<Student> students { get; set; }
    }
