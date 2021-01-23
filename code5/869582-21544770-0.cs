        protected void GridView1_OnSorting(object sender, GridViewSortEventArgs e)
        {
            //TODO write tour code here to get data from database;
             DataTable dataTable = your datatable get from your db;
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " "+e.SortDirection;
                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }
        }
    **e.SortExpression** provides sorting column name 
    
    **e.SortDirection** provides sorting direction like ASC or DESC.
 
