    ctx.Load(ctx.Web, w => w.Title);
    ctx.ExecuteQuery();
    //Results:
    ctx.Web.IsObjectPropertyInstantiated("Lists")  False
    ctx.Web.IsPropertyAvailable("Title")    True
