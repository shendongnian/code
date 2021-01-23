    List<string> columns = new List<string>();
    columns .Add("price");
    columns .Add("quantity");
    columns .Add("bid");
    columns .Add("price");
    foreach(string columnName in columns)
    {
        if(MyTable.Columns[columnName] == null)
        {
            //Col does not exist so add it:
            MyTable.Columns.Add(columnName);
        } 
    }
