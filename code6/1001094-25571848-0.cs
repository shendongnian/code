        // gridViewSorting and ConvertSortDirectionToSql are both necessary to ensure the gridview can sort when their column headers are
        //   clicked.  You must remember to add (AllowSorting="True" OnSorting="gridViewSorting") to the gridview tag on the ASP side
        protected void gridViewSorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = GVInactive.DataSource as DataTable;
            string sortExpression = e.SortExpression; 
            string direction = string.Empty;
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                if (SortDirection == SortDirection.Ascending) 
                { 
                    SortDirection = SortDirection.Descending; 
                    direction = " DESC"; 
                } 
                else 
                { 
                    SortDirection = SortDirection.Ascending; 
                    direction = " ASC"; 
                }
                DataTable table = GVInactive.DataSource as DataTable;
                table.DefaultView.Sort = sortExpression + direction;
                GVInactive.DataSource = table;
                GVInactive.DataBind();
            }
        }
        public SortDirection SortDirection 
        { 
            get 
            { 
                if (ViewState["SortDirection"] == null) 
                { 
                    ViewState["SortDirection"] = SortDirection.Ascending; 
                } 
                return (SortDirection)ViewState["SortDirection"]; 
            } 
            set 
            { 
                ViewState["SortDirection"] = value; 
            } 
        }
