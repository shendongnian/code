    public void AddStudentsToList()
    {
        List<Student> students = new List<Student>();
        HashSet<int> ids = new HashSet<int>(students.Select(s => s.ID));
        foreach (Student student in source)
        {
            if (!ids.Contains(student.ID))
            {
                students.Add(new Student(student));
            }
        }
    }
