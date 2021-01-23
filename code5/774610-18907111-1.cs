    IQueryable<Student> students = myDataContext.Students; //eg DbSet<Students>
    
    if (cond1) { 
       students = students.Where(s => s.Name == "Adam");
    }
    
    if (cond2) { 
       students = students.Where(s => s.Age > 20);
    }
    
    var matchedStudents = students.ToList();
