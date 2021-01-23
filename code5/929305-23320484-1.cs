    public List<Student> stList;
    public  List<Student> GetStudents()
    {
        using (EntityFWEntities OE = new EntityFWEntities())
        {
            //Assuming student has 4 properties ID, Name, Roll, DOB
            stList = OE.Students.Select(s=> new MvcApplication4.Models.Student(){ ID=s.ID, Name=s.Name, Roll=s.Roll, DOB=s.DOB}).ToList();
        }
    }
