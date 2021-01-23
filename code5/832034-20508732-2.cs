    GraphClient client = GetNeo4jGraphClient();
    client.Connect();
    client.Cypher
        .Merge("(user:User {Id: {newUser}.Id })")
        .OnCreate()
        .Set("user = {newUser}")
        .WithParams(
                    new { 
                        newUser =
                                new { 
                                    Id = 1, 
                                    Name = "Michael", 
                                    Title = "Developer Advocate", 
                                    FavoriteDatabase = "Neo4j",
                                    Occupation = "Software Developer"
                                }
        })
        .ExecuteWithoutResults();
