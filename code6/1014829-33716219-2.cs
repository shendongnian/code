    // Create.
    var newUser = dbContext.Users.Create();
    // Add.
    dbContext.Users.Add(newUser);
    
    // Remove.
    dbContext.Users.Remove(someUser);
    
    // Query.
    var john = dbContext.Users.Where(u => u.Name == "John");
    
    // Save changes won't actually do anything, since all the data is kept in memory.
    // This should be ideal for unit-testing purposes.
    dbContext.SaveChanges();
