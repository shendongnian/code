    public class Student
    {
        public int Id { get; set; }
        public List<Subject> Subjects { get; set; }
    }
    
    public class Subject
    {
        public string Name { get; set; }
        public string Status { get; set; } // enum or boolean is better
    }
