    if(userChoseFirst)
    {
      db = new MyDbContext("firstConnection"); 
    }
    else
    {
      db = new MyDbContext("secondConnection"); 
    }
    
