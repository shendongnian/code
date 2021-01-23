    var query = from lst in ctx.Web.Lists where lst.Title == "SomeList" select lst;
    var lists = ctx.LoadQuery(query);
    ctx.ExecuteQuery();
    ctx.Web.IsObjectPropertyInstantiated("Lists") -> True
    ctx.Web.Lists.ServerObjectIsNull -> False
    ctx.Web.Lists.Count -> CollectionNotInitializedException
