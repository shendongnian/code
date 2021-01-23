    public IEnumerable<Student> GetStudents()
    {
        return context.Students
                    .Select(s => new {s.FirstName})
                    .AsEnumerable()
                    .Select(s => new Student {FirstName=s.FirstName});
    }
