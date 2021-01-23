    public void QueryOrderBy<T>(T myValue)
    {
        var query = table.AsEnumerable()
                         .OrderBy(x => x.Field<T>(myValue))
                         .CopyToDataTable();
    }
