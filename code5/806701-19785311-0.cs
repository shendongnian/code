    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public int percentage { get; set; }
        public string type { get; set; }
    }
    
    public class Response
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<Student> students { get; set; }
    }
