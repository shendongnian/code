    var list = ctx.Web.Lists.GetByTitle(listTitle);
    var item = list.GetItemById(itemId);
    ctx.Load(item);
    ctx.ExecuteQuery();
                
    var author = (Microsoft.SharePoint.Client.FieldUserValue) item["Author"];
    var authorUser = ctx.Web.SiteUsers.GetById(author.LookupId);
    ctx.Load(authorUser);
    ctx.ExecuteQuery();
