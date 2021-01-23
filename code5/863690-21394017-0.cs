    ClientContext context = new ClientContext("http://mySharepointSite.com");
    List list = context.Web.Lists.GetByTitle("Tasks");
    CamlQuery query = new CamlQuery();
    query.ViewXml = "<View/>";
    ListItemCollection items = list.GetItems(query);
    
    context.Load(list);
    context.Load(items);
    
    context.ExecuteQuery();
