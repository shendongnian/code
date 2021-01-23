    ctx.Load(ctx.Web, w=>w.Lists,w=>w.Title);
    ctx.ExecuteQuery();
    //Results
    ctx.Web.IsObjectPropertyInstantiated("Lists")  True
    ctx.Web.IsPropertyAvailable("Title")    True
