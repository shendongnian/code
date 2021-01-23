    DataColumn totalColumn = new DataColumn();
    totalColumn.ColumnName = "FinalTotal";
    totalColumn.DataType = typeof (int);
    totalColumn.DefaultValue = 0;
    dtSourceTable.Columns.Add(totalColumn);
        
    foreach (DataRow row in dtSourceTable.Rows)
    {
        row["FinalTotal"] = Convert.ToInt32
           (row["HeadCount"]) - Convert.ToInt32(row["Total"]);
    }
