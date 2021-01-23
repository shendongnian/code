    ClientContext ctx = new ClientContext("URL");
    
    SP.Web web = ctx.Web;
    ctx.Load(web, w => w.AvailableContentTypes);
    
    var cts = ctx.Web.AvailableContentTypes;
    
    ctx.ExecuteQuery();
    
    var groups = cts.ToList().Select(ct => ct.Group).Distinct();
