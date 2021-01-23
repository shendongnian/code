    Try avoiding unnecessary loops and go for this if needed.
    
    string SearchByColumn = "ColumnName=" + value;
    DataRow[] hasRows = currentDataTable.Select(SearchByColumn);
    if (hasRows.Length == 0)
    { //your logic goes here    }
    else
    {
      //your logic goes here
    }
    
    if you want to search by specific ID then there should be a primary key in a table.
