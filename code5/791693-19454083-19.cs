    StringBuilder sb = new StringBuilder(); 
    
    IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                      Select(column => column.ColumnName);
    sb.AppendLine(string.Join("|", columnNames));
    
    foreach (DataRow row in dt.Rows)
    {
        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
        sb.AppendLine(string.Join("|", fields));
    }
    
    File.WriteAllText(@"c:\temp\data.psv", sb.ToString());
