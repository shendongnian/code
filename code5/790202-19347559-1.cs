    public class Student
    {
        public Student()
        {
            Marks = new List<StudentMark>();
        }
        public string Name { get; set; }
        public List<StudentMark> Marks { get; set; }
        public void Load(string line)
        {
            string[] parts = line.Split(' ');
            Name = parts[0];
            //Other properties, if any:
            //LastName = parts[1];
        }
    }
    public class StudentMark
    {
        public float Mark { get; set; }
        public string Lesson { get; set; }
    }
