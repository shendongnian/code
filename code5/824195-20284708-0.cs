    private string FormatStringByIndex(object field, int index)
    {
        if (index > 0 && index < 3)
            return string.Format("{0:yyyy-MM-dd HH:mm:ss.fffffff}", field);}
        else
            return field.ToString();
    }
    
    // ...
    
    StringBuilder sb = new StringBuilder();
    var columnNames = dt.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray();
    sb.AppendLine(string.Join(",", columnNames));
    foreach (DataRow row in dt.Rows)
    {
       var fields =   row.ItemArray.Select((field, index) => "\"" + FormatStringByIndex(field, index).Replace("\"", "\"\"") + "\"").ToArray();
       sb.AppendLine(string.Join(",", fields));
    }
