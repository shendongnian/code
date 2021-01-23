    using (var ctx = new ClientContext(webUri))
    {
    
         ctx.Load(ctx.Web, w => w.Lists, w => w.Title);
         ctx.ExecuteQuery();
         if (ctx.Web.IsPropertyAvailableOrInstantiated(w => w.Title))
         {
             //...
         }
         if (ctx.Web.IsPropertyAvailableOrInstantiated(w => w.Lists))
         {
             //...
         }
    } 
