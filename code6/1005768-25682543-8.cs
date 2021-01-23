    ctx.Load(ctx.Web, w => w.Lists);
    ctx.ExecuteQuery();
    //Results:
    ctx.Web.IsObjectPropertyInstantiated("Lists")  True
    ctx.Web.IsPropertyAvailable("Title")    False
