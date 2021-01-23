    var list = ctx.Web.Lists.GetByTitle(config.ListName); //ctx is your ClientContext
    var collection = list.GetItems(SP.CamlQuery.CreateAllItemsQuery()); //using SP = Microsoft.SharePoint.Client;
    ctx.Load(collection);
    ctx.ExecuteQuery();
    foreach (var item in collection)
    {
        Console.WriteLine(item["Title"] == "XYZ");
    }
