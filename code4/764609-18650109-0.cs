    SqlDataSource2.SelectCommand = "NEW SQL COMMAND";
    DataView testView = (DataView)SqlDataSource2.Select(DataSourceSelectArguments.Empty);
    DataTable table = testView .ToTable();
    
    DropDownList1.Datasource = table;
    DropDownList1.Databind();
