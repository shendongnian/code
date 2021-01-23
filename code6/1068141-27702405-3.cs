    table.Columns.Cast<DataColumn>()
        .ToList()
        .ForEach(col =>
        {
            if (col.ColumnName.StartsWith("Id"))
                header.Add(col.ColumnName)
        });
