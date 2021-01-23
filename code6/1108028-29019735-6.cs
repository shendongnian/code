    public class StudentList
    {
        public List<Student> Students { get; set; }
        public StudentList()
        {
            Students = new List<Student>
            {
                new Student {Name = "Student 1"},
                new Student {Name = "Student 2"},
                new Student {Name = "Student 3"}
            };
        }
    }
    public class Student
    {
        public string Name { get; set; }
    }
