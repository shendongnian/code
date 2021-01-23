    // Test by self-composed connection string.
    using (TestDbContext db = new TestDbContext(dbConn))
    {
        // Create database. 
        // If failed to connect to the database server, it will throw an exception.
        db.Database.CreateIfNotExists();
        // Insert an item.
        var item = new Test() { Field="Hello World!!"};
        db.TestSet.Add(item);
        db.SaveChanges();
        // Delete database after testing
        db.Database.Delete();
    }
