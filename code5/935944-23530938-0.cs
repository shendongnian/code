    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    Dictionary<int, Student> students = new Dictionary<int, Student>();
    List<Student> duplicates = new List<Student>();
    private void ReadStudents(IEnumerable<Student> source)
    {
        // source could contain the same student more than once
        foreach (Student student in source)
        {
            if (students.ContainsKey(student.ID))
                duplicates.Add(student);
            else
                students[student.ID] = student;
        }
    }
    public void Test()
    {
        List<Student> input = new List<Student>() { 
            new Student { ID=1, Name="Adam", Age=18 },
            new Student { ID=2, Name="Bert", Age=18 },
            new Student { ID=3, Name="Charlie", Age=19 },
            new Student { ID=1, Name="Adam", Age=18 }, // duplicate
        };
        ReadStudents(input);
        // 'students' now contains the list with duplicates removed
        // 'duplicates' contains all the duplicates
    }
