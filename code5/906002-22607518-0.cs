    public class Course
    {
        public string Title { get; set; }
    
        [XmlElement("Student")]
        public List<Student> Students { get; set; }
    }
