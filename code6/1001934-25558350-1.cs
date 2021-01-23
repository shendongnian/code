        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvMain.DataSource = new List<object> { new { ID = 1, Name = "First" }, new { ID = 2, Name = "Second" } };
                gvMain.DataBind();
            }
        }
        protected void gvMain_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView hGrid = (GridView)sender;
                GridViewRow gvrRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                DropDownList ddl = new DropDownList();
                ddl.Items.Add("Option 1");
                TableHeaderCell tcCell = new TableHeaderCell();
                tcCell.Controls.Add(ddl);
                gvrRow.Cells.Add(tcCell);
                gvMain.Controls[0].Controls.AddAt(0, gvrRow);
            }            
        }
