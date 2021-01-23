    string server = "http://localhost";
    var ctx = new ClientContext(server);
    var web = ctx.Web;
    var list = web.Lists.GetByTitle("Contacts");
    var listItemCollection = list.GetItems(CamlQuery.CreateAllItemsQuery());
    
    // always use QueryTrimming to minimize size of 
    // data that has to be transfered
    
    ctx.Load(listItemCollection,
               eachItem => eachItem.Include(
                item => item,
                item => item["CustomerId"]));
    // ExecuteQuery will pull all data from SharePoint
    // which has been staged to Load()
    ctx.ExecuteQuery();
    
    foreach(ListItem listItem in listItemCollection)
    {
       Console.WriteLine(listItem["CustomerId"]);
    }
