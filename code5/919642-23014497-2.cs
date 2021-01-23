    using (var context = new DBEntities())
    {
        var student = (from s in context.Students where s.studID == "001" select s).FirstOrDefault<Student>();               
        foreach (Course c in student.Courses.ToList())
        {
            student.Courses.Remove(c);
        }
        context.SaveChanges();
    }
