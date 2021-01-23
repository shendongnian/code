    using (var context = new SchoolDBEntities())
    {
        Student newStudent = new Student() { StudentName = "New Student using SP"};
    
        context.Students.Add(newStudent);
        //will execute sp_InsertStudentInfo 
        context.SaveChanges();
    
        newStudent.StudentName = "Edited student using SP";
        //will execute sp_UpdateStudent
        context.SaveChanges();
    
        context.Students.Remove(newStudent);
        //will execute sp_DeleteStudentInfo 
        context.SaveChanges();
    }
