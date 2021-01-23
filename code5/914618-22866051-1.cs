    var newDataTable = new DataTable();
    newDataTable.Columns.Add("Column1");
    newDataTable.Columns.Add("Column2");
    
    foreach(var item in temp123)
    {
       var newRow = newDataTable.NewRow();
       newRow["Column1"] = item.Column1;
       newRow["Column2"] = item.Column2;
       newDataTable.Rows.Add(newRow);
    }
