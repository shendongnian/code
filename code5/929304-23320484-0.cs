    public List<Student> stList;
    public  List<Student> GetStudents()
    {
        using (EntityFWEntities OE = new EntityFWEntities())
        {
            stList = OE.Students.ToList();
        }
    }
