    DataTable table = new DataTable();
    table.Columns.Add("col1", typeof(string));
    table.Columns.Add("col2", typeof(string));
    
    String val="One,Two;Three,Four;Five,Six";
    string[][] values=val.Split(';').Select(x => x.Split(',')).ToArray();
    
    for (int i= 0; i< values.Length; i++)
       {
           DataRow newRow = table.NewRow();
           for (int j= 0; j< 2; j++)
            {
               newRow[i] = values[i,j];
            }
           table.Rows.Add(newRow);
        }
    
