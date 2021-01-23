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
        private void BindGrid()
        {
            DataTable dt = new [However you get dataset from database];
            DataView dv = new DataView(dt);
            dv.Sort = string.Format("{0} {1}", SortCriteria, SortDirection).Trim();
            gvData.DataSource = dv;
            gvData.DataBind();
        }
