    #region For Grid view Header Sorting..!!
        public SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }
    
        protected void grdAdd_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortingDirection = string.Empty;
            if (dir == SortDirection.Ascending)
            {
                dir = SortDirection.Descending;
                sortingDirection = "Desc";
            }
            else
            {
                dir = SortDirection.Ascending;
                sortingDirection = "Asc";
            }
            DataTable dtgrd = AdditionBL.BindAdditionMaster();/**Data Table Bind For Short View**/
            DataView sortedView = new DataView(dtgrd);
            sortedView.Sort = e.SortExpression + " " + sortingDirection;
            grdAddition.DataSource = sortedView;
            grdAddition.DataBind();
        }
        #endregion
