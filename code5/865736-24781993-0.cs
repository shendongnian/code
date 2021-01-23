    using System.Transactions; // Add assembly in references
    using (var db = C2SCore.BuildDatabaseContext())
    {
      using (var tran = new TransactionScope())
      {
        db.Users.Add(new UserProfile { UserName = UserName, Password = Password });
        db.SaveChanges(); // <- Should work now after first exception
      }
    }
