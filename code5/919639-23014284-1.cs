    Student student = context.Student.FirstOrDefault(s => s.studID == "001");
    if (student!=null)
    {
        student.Enrolls.Load();
        student.Enrolls.ToList().ForEach(e => context.Enroll.DeleteObject(e));
    }
