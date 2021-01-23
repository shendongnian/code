    DataTable dataTable = new DataTable();        
    dataTable = ds.Tables[0];
    
    if (dataTable != null)
    {
        DataView dataView = new DataView(dataTable);
        dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
        GridViewStudents.DataSource = dataView;
        GridViewStudents.DataBind();
    }
