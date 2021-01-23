    //Create student in disconnected mode
    Student newStudent = new Student() { StudentName = "New Single Student" };
        
    //Assign new standard to student entity
    newStudent.Standard = new Standard() { StandardName = "New Standard" };
        
    //add new course with new teacher into student.courses
    newStudent.Courses.Add(new Course() { CourseName = "New Course for single student", Teacher = new Teacher() { TeacherName = "New Teacher" } });
    using (var context = new SchoolDBEntities())
    {
        context.Students.Add(newStudent);
        context.SaveChanges();
        Console.WriteLine("New Student Entity has been added with new StudentId= " + newStudent.StudentID.ToString());
        Console.WriteLine("New Standard Entity has been added with new StandardId= " + newStudent.StandardId.ToString());
        Console.WriteLine("New Course Entity has been added with new CourseId= " + newStudent.Courses.ElementAt(0).CourseId.ToString());
        Console.WriteLine("New Teacher Entity has been added with new TeacherId= " + newStudent.Courses.ElementAt(0).TeacherId.ToString());
    }
