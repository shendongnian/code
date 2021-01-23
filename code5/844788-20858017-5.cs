    IMongoQuery query = Query.EQ("Activity", 1);         
    UpdateBuilder ub = Update.Unset("two");
    MongoUpdateOptions options = new MongoUpdateOptions {
        Flags = UpdateFlags.Multi
    };
    var updateResults = examples.Update(query, ub, options);
