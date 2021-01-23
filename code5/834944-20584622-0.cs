    foreach(DataColumn column in dt.Columns)
    {
      column.Caption.Replace("_"," "); 
      //or column.ColumnName
    }
