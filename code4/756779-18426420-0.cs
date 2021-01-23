    public IList<Student> FindByType(string type)
    {
        //Replace e.StartsWith with whatever method you wish to filter by
        var studentTypeNames =typeof(StudentType).GetEnumNames().Where(e => e.StartsWith(type)).ToList();
        var students = new List<Student>();
        foreach (var studentTypeName in studentTypeNames)
        {
            StudentType studentType;
            Enum.TryParse(studentTypeName, true, out studentType);
            students.AddRange(_students.AsQueryable().Where("Type  = (@0)", studentType).ToList());
        }
        return students;
    }
