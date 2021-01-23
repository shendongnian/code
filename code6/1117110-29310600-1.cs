    // Create a model + register types to it.
    var mb = new DbModelBuilder();
    mb.Entity<Company>();
    mb.Entity<Location>();
    
    // Or:
    //mb.RegisterEntityType(typeof(Company));
    //mb.RegisterEntityType(typeof(Location));
    // Build and compile the model
    var connString = @"server=myServer;database=theDataBase;Integrated Security=SSPI;MultipleActiveResultSets=True";
    
    var dbModel = mb.Build(new SqlConnection(connString));
    
    var compiledModel = dbModel.Compile();
    // Create a DbContext using the compiled model.
    var db = new DbContext(connString, compiledModel);
    Database.SetInitializer<DbContext>(null); // Prevent creation of migration table
    // Ready to go!
    var companies = db.Set<Company>().Include(c => c.Locations).ToList();
