        protected void GridViewStudents_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = new DataTable();        
            dataTable = ds.Tables[0];
    
            if (dataTable != null)
            {
             DataView dataView = new DataView(dataTable);
             dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
             GridViewStudents.DataSource = dataView;
             GridViewStudents.DataBind();
            }
        }
