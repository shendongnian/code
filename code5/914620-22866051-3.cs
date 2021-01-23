    var newDataTable = new DataTable();
    newDataTable.Columns.Add("Column1");
    newDataTable.Columns.Add("Column2");
    
    foreach(var item in temp123)
        newDataTable.Rows.Add(item.Column1, item.Column2);
