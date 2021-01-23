    public void AddStudentsToList()
    {
    List<Student> students = new List<Student>();
    foreach (Student student in source)
    {
        if (!students.where(s => s.ID == student.ID).any())
        {
            students.Add(new Student(student));
        }
    }
    }
