    ClientContext ctx = new ClientContext(Site);
    ctx.Credentials = new NetworkCredential(userName, passWord, "dmz");               
    List list = ctx.Web.Lists.GetByTitle(SpList);
    ListItemCollection items = list.GetItems(CamlQuery.CreateAllItemsQuery());
    ctx.Load(items); // loading all the fields              
    ctx.ExecuteQuery();
    foreach (var item in items)
    {
        if (((FieldUrlValue)(item["VideoSetExternalLink"])).Url.ToString() != VideoURL)
        {
            FieldUrlValue va = ((FieldUrlValue)(item["VideoSetExternalLink"]));
            va.Url = vp.VideoURL;
            item["VideoSetExternalLink"] = va;
            item.Update(); 
        }
    }
    ctx.Load(items);
    ctx.ExecuteQuery();
    This is how i Fixed the issue. 
