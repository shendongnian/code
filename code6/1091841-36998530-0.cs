    var listTitle = "Documents";
    var query = new CamlQuery();
    query.ViewXml = "<View Scope='RecursiveAll' />";
    var items = ctx.Web.Lists.GetByTitle(listTitle).GetItems(query);
    string[] fieldsToMigrate = new string[] { "Title", "FieldA", "FieldB" };
    ctx.Load(items, a => a.Include(b => b.ContentType, b => b["FileRef"]));
    foreach (var f in fieldsToLoad) {
        ctx.Load(items, includes => includes.Include(a => a[f]));
    }
    
    ctx.ExecuteQuery();
