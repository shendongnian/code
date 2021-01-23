    var newDt = dt.AsEnumerable().Select(
        row => dt.Columns.Cast<DataColumn>().ToDictionary(
            column => column.ColumnName,    
            column => row[column].ToString()
        )
    );
