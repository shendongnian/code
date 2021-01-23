    [Queryable]
    public SingleResult<Player> GetPlayer([FromODataUri]int key)
    {
        return SingleResult.Create(_db.Players.Where(c => c.PlayerId == key));
    }
