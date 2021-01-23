    for (int i = 0; i < al.Count; i++)
    {
     var student = al[i] as Student;
    
     if (student != null)
     {
            Console.WriteLine("Roll "+ student.roll.ToString());
            Console.WriteLine("Name "+ student.name);
            Console.WriteLine("Course "+ student.course);
     }
     else
     {
      var employee  = al[i] as Employee;
    
      if (employee  != null)
      {
            Console.WriteLine("EmpID "+ employee.empID.ToString());
            Console.WriteLine("EmpName "+ employee.name);
      }
     }
    }
