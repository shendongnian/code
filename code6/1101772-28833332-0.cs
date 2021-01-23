    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentContact StudentContact { get; set; }
    }
    public class StudentContact
    {
        [Key, ForeignKey("Student")]
        public int StudentId { get; set; }
        public int Contact { get; set; }
        public Student Student { get; set; }
    }
