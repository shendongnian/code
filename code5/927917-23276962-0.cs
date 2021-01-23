    var ColumnToIngorn = DataTable.Columns["XXX"].Ordinal;
    for (int i = 0; i < DataTable.Columns.Count; i++)
    {
        if(i == ColumnToIngorn)
            ...
    }
