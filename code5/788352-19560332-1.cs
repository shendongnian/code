    //Removed: System.Data.Entity.Database.SetInitializer<MyDbContext>(new DatabaseTestInitializer());
    this.Db = Container.Resolve<MyDbContext>();
    this.Db.Should().NotBeNull();
    //Below: code added
    this.Db.Database.Delete();
    this.Db.Database.Create();
    SeederHelper.Seed(this.Db);
