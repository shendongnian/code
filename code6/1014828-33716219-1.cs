    // Create test data.
    var contracts = new List<Contract>
    {
        new Contract("#1"),
        new Contract("#2")
    };
    
    var users = new List<User>
    {
        new User("John"),
        new User("Jane")
    };
    // Create DbContext with the predefined test data.
    var dbContext = MyMoqUtilities.MockDbContext(
        contracts: contracts,
        users: users).DbContext.Object;
    
