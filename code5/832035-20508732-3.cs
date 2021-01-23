    GraphClient client = GetNeo4jGraphClient();
    client.Connect();
    client.Cypher.Match("(user:User {Id: {newUser}.Id })")
        .Set("user = {newUser}")
        .WithParams(
                    new
                    {
                        newUser =
                                new
                                {
                                    Id = 1,
                                    Name = "Kenny",
                                    Title = "Developer Advocate",
                                    FavoriteDatabase = "Neo4j",
                                    Occupation = "Software Developer"
                                }
                    })
        .ExecuteWithoutResults();
