    using(var db = new yourDbContext())
    {
    
    User user = new User();
    
    user.Name = "Name";
    
    db.User.Add(user);
    
    db.SaveChanges();
  
    Computer computer = new Computer();
    
    // set properties here if any
    
    Computer.CopmuterName ="Dell";
    
    Computer.user = user;
    db.Computer.Add(Computer);
    
    db.SaveChanges();
    }
