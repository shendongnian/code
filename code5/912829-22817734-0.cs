    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {      
            DataTable dtSortTable = GridView1.DataSource as DataTable;
     
            if (dtSortTable != null)
            {
                DataView dvSortedView = new DataView(dtSortTable);
     
                dvSortedView.Sort = e.SortExpression + "" + getSortDirectionString(e.SortDirection);
            
                GridView1.DataSource = dvSortedView;
                GridView1.DataBind();
            }
        }
