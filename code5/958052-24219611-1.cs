    foreach (var stdnt in students)
    {
          if (stdnt.Marks >= 75)
          {
               var student = new Student(); // create a new student here!
               student.Marks = stdnt.Marks;
               student.Name = stdnt.Name;
               toppers.Add(student);
           }
       }
