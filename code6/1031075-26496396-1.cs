    var wikiPages = ctx.Web.Lists.GetByTitle(listTitle);
    var query = new CamlQuery
                    {
                        ViewXml = "<View><Query><OrderBy><FieldRef Name='ID' Ascending='FALSE'/></OrderBy></Query><RowLimit>1</RowLimit></View>"
                    };
    var items = wikiPages.GetItems(query);
    ctx.Load(items, icol => icol.Include(i => i.File));
    ctx.ExecuteQuery();
    if (items.Count == 1)
    {
        var pageFile = items[0].File; 
        Console.WriteLine(pageFile.Name);
    }        
