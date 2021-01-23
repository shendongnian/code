    using System.Data.Entity;
    using Projekt5.Migrations;
    ....
    string relative = @"..\..\App_Data\Cos.mdf";
    string absolute = Path.GetDirectoryName(absolute);
    AppDomain.CurrentDomain.SetData("DataDirectory", absolute);
    Database.SetInitializer(new
        MigrateDatabaseToLatestVersion<Projekt5Context, Configuration>()
     );
    // database not created yet
    using (var db = new Projekt5Context())
    {
      db.Things.Add(new Thing { Name = "OMG This works!" });
      db.SaveChanges();
    } 
    // database CREATED!
