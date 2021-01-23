    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridview();
            }
        }
        protected void gvStations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                //This enables the EditTemplate
                int rowindex = ((GridViewRow) ((LinkButton) e.CommandSource).NamingContainer).RowIndex;
                gvStations.EditIndex = rowindex; //Enables the edit row in gridview      
                LoadGridview();
            }
            else if (e.CommandName == "CancelUpdate")
            {
                gvStations.EditIndex = -1;
                LoadGridview();
            }
            else if (e.CommandName == "UpdateRow")
            {
                //DO SOME STUFF///
                gvStations.EditIndex = -1; //Takes you out of update view      
                LoadGridview();
            }
        }
        private void LoadGridview()
        {
            if (Session["sortedGV"] == null)
            {
                var table = new DataTable();
                table.Columns.Add("StationId", typeof (int));
                table.Columns.Add("StationNumber", typeof (string));
                DataRow row1 = table.NewRow();
                row1["StationId"] = 1;
                row1["StationNumber"] = "343";
                table.Rows.Add(row1);
                DataRow row2 = table.NewRow();
                row2["StationId"] = 2;
                row2["StationNumber"] = "443";
                table.Rows.Add(row2);
                Session["sortedGV"] = new DataView(table);
            }
            gvStations.DataSource = Session["sortedGV"];
            gvStations.DataBind();
        }
        private void SortGridview(string sortExpression, string Direction)
        {
            var dv = (DataView) Session["sortedGV"];
            dv.Sort = sortExpression + " " + Direction;
            LoadGridview();
        }
        //Sorts gridview
        protected void gvStations_Sorting(object sender, GridViewSortEventArgs e)
        {
            String sortExpression = e.SortExpression;
            Session["SortExpression"] = sortExpression;
            if (Session["SortDirection"] != null &&
                Session["SortDirection"].ToString() == SortDirection.Descending.ToString())
            {
                Session["SortDirection"] = SortDirection.Ascending;
                SortGridview(sortExpression, "ASC");
            }
            else
            {
                Session["SortDirection"] = SortDirection.Descending;
                SortGridview(sortExpression, "DESC");
            }
        }
