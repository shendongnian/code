    foreach (string ColumnName in AllColumns)
    {
        List<string> values_ofColumn = null;
        var coll =  (
                                    from row in MasterDataTableObject.AsEnumerable()
                                    select row[ColumnName]
                    );
        values_ofColumn = coll.Select(row => row.ToString()).Distinct().ToList<string>();
    }
