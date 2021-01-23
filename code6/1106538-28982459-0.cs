    public static bool FileExists(List list, string fileUrl)
    {
        var ctx = list.Context;
        var qry = new CamlQuery();
        qry.ViewXml = string.Format("<View Scope=\"RecursiveAll\"><Query><Where><Eq><FieldRef Name=\"FileRef\"/><Value Type=\"Url\">{0}</Value></Eq></Where></Query></View>",fileUrl);
        var items = list.GetItems(qry);
        ctx.Load(items);
        ctx.ExecuteQuery();
        return items.Count > 0;
    }
