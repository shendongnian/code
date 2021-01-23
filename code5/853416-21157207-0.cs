	private bool UpdateDataLog(BsonValue Id, List<Ping> tempPings, MongoCollection<Datalog> mongoCollection)
    {
        bool success = false;
        try
        {
            var query = new QueryDocument("_id", Id);
            var update = Update<Datalog>.PushAll(e => e.Pings, tempPings);
            mongoCollection.Update(query, update);
            success = true;
        }
        catch (Exception ex)
        {
            string error = ex.Message;
        }
        return success;
    }
