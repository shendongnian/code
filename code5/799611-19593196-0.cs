    private void CopyColumns(DataTable source, DataTable dest, params string[] columns)
    {
      dest = source.AsEnumerable()
                   .Select(row=> {
                       DataRow newRow = dest.NewRow();
                       bool first = true;
                       foreach(var col in columns) {
                         if(first) {
                           newRow[col] = ((string) row[col]).Replace("USD","").Trim('/');
                           first = false;
                         }
                         else newRow[col] = row[col];
                       }
                       return newRow;  
                    }).CopyToDataTable();
    }
