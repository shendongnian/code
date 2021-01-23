    private void CopyColumns(DataTable source, DataTable dest, params string[] columns)
    {
      dest = source.AsEnumerable()
                   .Select(row=> {
                       DataRow newRow = dest.NewRow();
                       newRow[columns[0]] = ((string)row[columns[0]])
                                           .Replace("USD","").Trim('/');                      
                       for(int i = 1; i < columns.Length; i++) {
                         newRow[columns[i]] = row[columns[i]];
                       }
                       return newRow;  
                    }).CopyToDataTable();
    }
