    using (var dc = new TestEntities())
    {
        var query = ...;// your query
        var oquery = query as System.Data.Objects.ObjectQuery;
        Console.WriteLine(oquery.ToTraceString());
    }
