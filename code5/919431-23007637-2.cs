    protected void  _propertyGridView_Sorting(object sender, GridViewSortEventArgs e)
    { 
    SetSortDirection(SortDireaction);
    if (dataTable != null)
    {
        //Sort the data.
        dataTable.DefaultView.Sort = e.SortExpression + " " +_sortDirection;
         _propertyGridView.DataSource = ExecuteStoredProcedure(StoredProcedure,parameter);
         _propertyGridView.DataBind();
        SortDireaction = _sortDirection;
    }
    } 
    protected void SetSortDirection(string sortDirection)
    {
    if (sortDirection == "ASC")
   
     {
        _sortDirection = "DESC";
    }
    else
    {
        _sortDirection = "ASC";
    }
    } 
    public static DataTable ExecuteStoredProcedure(string strProc,SqlParameter[]paramArray)
    {
    SqlCommand command = new SqlCommand(strProc, connection);
    command.CommandType = CommandType.StoredProcedure;
    SqlDataAdapter adapter = new SqlDataAdapter(command);
    DataTable table = new DataTable();
    adapter.Fill(table);
    connection.Close();
    return(table);
    }
