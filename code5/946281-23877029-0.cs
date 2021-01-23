    var query = Query<App>.EQ(a => a.Id, entity.Id);
    var itemIndex = entity.AppUsers.FindIndex(u => u.Id == userId);
    var updateResult = this.MongoConnectionHandler.MongoCollection.Update(
                       query,
                       Update<App>.Push(a => a.AppUsers[itemIndex].BookIds, bookId),
    
                       new MongoUpdateOptions()
                       {
                           WriteConcern = WriteConcern.Acknowledged,
                       });
