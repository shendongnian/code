    var query = Query.And(
        Query.EQ("_id", entity.Id),
        Query.EQ("AppUsers.uId", UserId)
    );
    var update = Update.Push("AppUsers.$.BookIds", bookId);
    var updateResult = this.MongoConnectionHandler.MongoCollection.Update(
        query, update);
