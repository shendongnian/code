        private string SortExpression
        {
            get { return (string) Session["SortExpression"]; }
            set { Session["SortExpression"] = value; }
        }
        private string Direction
        {
            get { return (string)Session["SortDirection"]; }
            set { Session["SortDirection"] = value; }
        }
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
                var dataView = (DataView) Session["sortedGV"];
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
                SortGrid();
            }
            gvStations.DataSource = Session["sortedGV"];
            gvStations.DataBind();
        }
        private void SortGrid()
        {
            var dv = (DataView) Session["sortedGV"];
            if (SortExpression != null)
            {
                dv.Sort = SortExpression + " " + Direction;
                
            }
        }
        //Sorts gridview
        protected void gvStations_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortExpression = e.SortExpression;
            if (SortExpression != null &&
                Direction == SortDirection.Descending.ToString())
            {
                Direction = "ASC";
            }
            else
            {
                Direction = "DESC";       
            }
            SortGrid();
            LoadGridview();
        }
