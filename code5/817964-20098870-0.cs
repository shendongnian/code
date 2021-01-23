    public StudentCourse CreateOrUpdate(VM_StudentCourse studentCourse)
    {
        StudentCourse dbStudentCourse;
        using (var context = new StudentContext()
        {
            dbStudentCourse = context.StudentsCourses.FirstOrDefault(x => x.StudentId == studentCourse.studentId && x.CourseId == studentCourse.courseId);
            If (dbStudentCourse == null)
            {
               dbStudent = new StudentCourse();
               dbStudent.StudentId = studentCourse.StudentId;
               dbStudent.CourseId = studentCourse.CourseId;
               context.Add(dbStudent);
            }
            dbStudent.OtherProperty1 = studentCourse.SomeProp;
            dbStudent.OtherProperty2 = studentCourse.SomeOtherProp;
            
            context.SaveChanges();
        }
        return dbStudentCourse;
    }
 
