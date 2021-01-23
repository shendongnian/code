        private string SortCriteria
        {
            get
            {
                if (ViewState["sortCriteria"] == null)
                {
                    ViewState["sortCriteria"] = "";
                }
                return ViewState["sortCriteria"].ToString();
            }
            set
            {
                ViewState["sortCriteria"] = value;
            }
        }
        private string SortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                {
                    ViewState["sortDirection"] = "";
                }
                return ViewState["sortDirection"].ToString();
            }
            set
            {
                ViewState["sortDirection"] = value;
            }
        }
        protected void gvData_Sorting(object sender, GridViewSortEventArgs e)
        {
            gvData.EditIndex = -1;
            if (SortCriteria == e.SortExpression)
            {
                if (SortDirection == string.Empty || SortDirection == "DESC") { SortDirection = "ASC"; }
                else { SortDirection = "DESC"; }
            }
            else
            {
                SortCriteria = e.SortExpression;
                SortDirection = "ASC";
            }
            BindGrid();
        }
