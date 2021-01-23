    var ArrItem = DataTable.Rows[rowIndex].ItemArray.Select((item, indexColumn) => new { index = indexColumn, value = item });
    foreach (var item in ArrItem)
    {
        if (item.index == 5) //Check index column
            ...
        if (DataTable.Columns[item.index].ColumnName == "XXX") //check name column
            ...
    }
