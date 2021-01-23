    // store the students as a List<>...
    private List<Student> students;
    // ...but expose them as IEnumerable<>.
    public IEnumerable<Student> Students
    {
        get { return this.students; }
    }
    // IEnumerable<> does not allow adding, removing, clearing, etc - 
    // you know you're the only one altering the data
    // and you can choose to give them restricted access with your own
    // validation logic
    public void AddStudent(Student student) 
    {
        if (this.students.Any(s => s.Number == student.Number))
            throw new ArgumentException("Duplicate student number!");
        this.students.Add(student);
    }
