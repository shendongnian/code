            stud = ctx.Students.Where(s => s.StudentName == "New Student1").FirstOrDefault<Student>();
        }
    
        //2. change student name in disconnected mode (out of ctx scope)
        if (stud != null)
        {
            stud.StudentName = "Updated Student1";
        }
    
        //save modified entity using new Context
        using (var dbCtx = new SchoolDBEntities())
        {
            //3. Mark entity as modified
            dbCtx.Entry(stud).State = System.Data.Entity.EntityState.Modified;     
            
            //4. call SaveChanges
            dbCtx.SaveChanges();
        }
