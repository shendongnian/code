    using System.Transactions; // Add assembly in references
    using (var db = C2SCore.BuildDatabaseContext())
    {
      using (var tran = new TransactionScope())
      {
        db.Users.Add(new UserProfile { UserName = UserName, Password = Password });
        db.SaveChanges(); // <- Should work now after first exception
        tran.Complete();
      }
    }
    <package id="MySql.Data" version="6.8.3" targetFramework="net45" />
    <package id="MySql.Data.Entities" version="6.8.3.0" targetFramework="net45" />
