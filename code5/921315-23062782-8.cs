    using(var db = new yourDbContext())
    {
    
    User user = new User();
    
    user.Name = "Name";
      
    user.Computer = new Computer();
    
    // set properties here if any
    
    user.Computer.CopmuterName ="Dell";
     
    db.User.Add(user);
    db.SaveChanges();
    }
