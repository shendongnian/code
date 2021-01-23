    // IEnumerable<> does not allow adding
    public IEnumerable<Student> Students
    {
        get { return this.students; }
    }
    public void AddStudent(Student student) 
    {
        if (this.students.Any(s => s.Number == student.Number))
            throw new ArgumentException("Duplicate student number!");
        this.students.Add(student);
    }
