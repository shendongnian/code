    var databaseClient = new MongoClient(DatabaseConnectionString);
    var server = databaseClient.GetServer();
    var database = server.GetDatabase("Users");
    var collection = database.GetCollection<User>("users");
    
    var user = collection.AsQueryable().First(o => o._id == YOURSESSIONID);
    
    user.Teams.Add(new Team { TeamID = 0, TeamName = "Some Team" });
 
