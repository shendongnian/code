    string SearchByColumn = "ColumnName=" + value;
    DataRow[] hasRows = currentDataTable.Select(SearchByColumn);
    if (hasRows.Length == 0)
    { //your logic goes here    }
    else
    {
      //your logic goes here
    }
