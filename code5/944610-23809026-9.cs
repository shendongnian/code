    protected void GridViewFoundations_Sorting1(object sender, GridViewSortEventArgs e)
                {
                    DataTable dataTable = GridViewFoundations.DataSource as DataTable;
    
                    if (dataTable != null)
                    {
                        DataView dataView = new DataView(dataTable);
                        this.GridSortDirection=ChangeSortDirection(e.SortDirection);
                        dataView.Sort = e.SortExpression + " " + GridSortDirection;
    
                        GridViewFoundations.DataSource = dataView;
                        GridViewFoundations.DataBind();
                    }
    
                }
