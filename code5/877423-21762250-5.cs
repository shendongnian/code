    var dt = new DataTable();
    dt.Columns.Add("Host"); 
    dt.Columns.Add("Path"); 
    dt.Columns.Add("Date"); 
    dt.Columns.Add("File"); 
    foreach (var item in results) 
    {   
        dt.Rows.Add(item.Host,item.Path,item.Date,item.File);                 
    }
