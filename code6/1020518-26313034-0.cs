    [EnableQuery]
    public IHttpActionResult GetTeam([FromODataUri] string id)
    {
        var teams = mongoDatabase.GetCollection("Teams");
        // convert the string 'id' to BsonValue 'bsonId'
        ......
         
        var team = teams.FindOneById(bsonId);
        
        // convert 'team' to the entity type Team object 'team'
        ......
        return Ok(team);
    }
