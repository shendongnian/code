     string str=string.Empty;
     foreach (DataColumn column in dt.Columns)
      {
               //write the logic so that last record doesnt have comma. leaving it to you.
               str= str+ column.ColumnName +",";
       }
