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
            ((FieldUrlValue)(item["VideoSetExternalLink"])).Url = vp.VideoURL;
            item.Update(); 
        }
    }
    ctx.ExecuteQuery();
