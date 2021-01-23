    // Iterate through the rows...
    table.AsEnumerable().Select(
        // ...then iterate through the columns...
        row => table.Columns.Cast<DataColumn>().ToDictionary(
            // ...and find the key value pairs for the dictionary
            column => column.ColumnName,    // Key
            column => row[column] as string // Value
        )
    )
