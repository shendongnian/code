       student st = new student 
        {
          fname = "fname",
          lname= "lname",
                            
          Enrollement_E=new List<Enrollement>
          {
            new Enrollement{kk="something"}
          }
        };
        
        repository.student.Add(st);
        repository.SaveChanges();
