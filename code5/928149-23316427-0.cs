    //Specify fields to retrieve via ClientContext.Load
    var list = context.Web.Lists.GetByTitle(listTitle);
    var qry = CamlQuery.CreateAllItemsQuery();
    var items = list.GetItems(qry);
    context.Load(items, icol => icol.Include(i => i["LinkTitle"], i => i["LinkTitleNoMenu"]));
