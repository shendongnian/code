    var cacheClient = new RedisClient();
    cacheClient.Watch("Users", "Groups");
	
    var userHash = cacheClient.As<User>().GetHash<string>("Users");
    var groupHash = cacheClient.As<Group>.GetHash<string>("Groups");
	using (var trans = cacheClient.CreateTransaction())
    {
        trans.QueueCommand(x =>
        {
            user = x.As<User>().GetValueFromHash(userHash, userKey);
        });
    
        trans.QueueCommand(y =>
        {
            group = y.As<Group>().GetValueFromHash(groupHash, groupKey);
        });
    
        trans.Commit();
    }
