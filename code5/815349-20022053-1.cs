    var tbl = db.Tables["person"];
    var dw = new DependencyWalker(server);
    var tree = dw.DiscoverDependencies(new SqlSmoObject[] {tbl}, DependencyType.Children);
    var cur = tree.FirstChild.FirstChild;
    while (cur != null)
    {
        var table = server.GetSmoObject(cur.Urn) as Table;
        if (table != null && table.ForeignKeys.Cast<ForeignKey>().Any(fk => fk.ReferencedTable == tbl.Name))
        {
            //do something with table.Name
        }
        cur = cur.NextSibling;
    }
