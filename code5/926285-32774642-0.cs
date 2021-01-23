    FindAndModifyArgs findAndModifyArgs;
    FindAndModifyResult mongoResponse;
    IMongoQuery   mongoQuery	  = Query.EQ  ("IsBusy", false);
    UpdateBuilder updateStatement = Update.Set("IsBusy", true);
    // Finding a not busy app, and updating it to busy.
    findAndModifyArgs = new FindAndModifyArgs()
    {
        Query 			= mongoQuery,
        Update		    = updateStatement,
        SortBy          = null,
        VersionReturned = FindAndModifyDocumentVersion.Modified
     };
    mongoResponse = _database.GetCollection<QueuedApp>(collectionName).FindAndModify(findAndModifyArgs);
    return BsonSerializer.Deserialize<QueuedApp>(mongoResponse.ModifiedDocument);
