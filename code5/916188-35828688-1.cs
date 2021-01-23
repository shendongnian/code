    public List<Structures.StudentInfo> GetListOfStudents()
    {
       return GetListOfStudents(null, null);
    }
    public List<Structures.StudentInfo> GetListOfStudents(string Username, string Password)
    {
        List<Structures.StudentInfo> si = StudentFunctions.GetListOfStudents(Username, Password);
        return si;
    }
