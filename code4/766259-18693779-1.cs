    var query = GraphClient
        .Cypher
        .Start(new {n = actorRef})
        .Match("n-[:HasItem]->item")
        .Return(
        item => new
        {
            Item = item.CollectAs<Dictionary<string,string>>()
        });
    var results = query.Results.ToList();
