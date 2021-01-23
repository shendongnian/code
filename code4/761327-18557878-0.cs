    using (var db = new MyEntities())
    {    
        using (var transaction = new TransactionScope())
        {
            var newGroup = new Groups
          {
              GroupDate = DateTime.Now,
              GroupName = "someName"
          };
          db.Groups.Add(newGroup);
          db.SaveChanges();
         }
     transaction.Complete();
    }
