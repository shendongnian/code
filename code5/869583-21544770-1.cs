        protected void GridView1_OnSorting(object sender, GridViewSortEventArgs e)
        {
            //TODO write tour code here to get data from database;
             DataTable dataTable = your datatable get from your db;
            if (dataTable != null)
            {
                    if (e.SortDirection.ToString() == "Ascending")
                    {
                        dataView.Sort = e.SortExpression + " ASC";
                    }
                    else if (e.SortDirection.ToString() == "Descending")
                    {
                        dataView.Sort = e.SortExpression + " DESC";
                    }
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " "+e.SortDirection;
                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }
        }
    **e.SortExpression** provides sorting column name 
    
    **e.SortDirection** provides sorting direction like ASC or DESC.
