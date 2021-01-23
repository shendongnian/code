       private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;
    
            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;
    
                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }
    
            return newSortDirection;
        }
    
        protected void GridView1_OnSorting(object sender, GridViewSortEventArgs e)
        {
    
            string strSql = "SELECT * FROM  TEST_Table Order by Date Desc ";
            DataSet ds = DataProvider.Connect_Select(strSql);
    
            //ds = DataProvider.GetFormByFormTypeIDForGridview(int.Parse(ddCareerType.SelectedItem.Value.ToString()));
            DataTable dataTable = ds.Tables[0];
    
            string SortDirection = "DESC";
            if (ViewState["SortExpression"] != null)
            {
                if (ViewState["SortExpression"].ToString() == e.SortExpression)
                {
                    ViewState["SortExpression"] = null;
                    SortDirection = "ASC";
                }
                else
                {
                    ViewState["SortExpression"] = e.SortExpression;
                }
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression;
            }
    
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + SortDirection;
                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }
        }
