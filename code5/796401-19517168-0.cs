    DataTable dataTable = new dataTable();
    dataTable.Columns.Add("Column1");
    dataTable.Columns.Add("Column2");
    dataTable.Columns.Add("Column3");
    
    DataRow dataRow = dataTable.NewRow();
    
    dataRow["Column1"] = "";
    dataRow["Column2"] = "";
    dataRow["Column3"] = "";
    
    dataTable.Rows.Add(dataRow);
    
    gridview1.DataSource = datatable;
    gridview1.DataBind();
