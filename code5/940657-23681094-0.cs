    var query = Session.QueryOver<Orders>();
    if (ids == null || ids.Count == 0)
    {
        query = query..WhereRestrictionOn(x => x.OrderId).IsIn(Ids);
    }
