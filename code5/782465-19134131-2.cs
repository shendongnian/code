    var column1Groups = ds.Tables[0].AsEnumerable()
        .GroupBy(r => r.Field<string>("Column1"));
    foreach(var group in column1Groups)
    {
        // if you need only the 1234  and 1000 groups:
        if(group.Key == "1000" || group.Key == "1234")
        {
            ds.Tables.Add(group.CopyToDataTable());
        }
    }
