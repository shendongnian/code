    var query = myDataTable.AsEnumerable()
      .OrderByDesending( x => x.Field<type>("columnName"))
      .GroupBy( x => x.Field<type>'columnName").Substring(0,lenght)
      .SelectMany(x => x).CopyToDataTable();
    
      DataView.Table = query;
      DataView.Table.AcceptChange();
