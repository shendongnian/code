        protected void Page_Load(object sender, EventArgs e)
        {
            var ds = new[] { 
                                new { Id = 0, Name = "Joe" }, 
                                new { Id = 1, Name = "Nick" } 
                           };
            GridView1.RowDataBound += new GridViewRowEventHandler(GridView1_RowDataBound);
            GridView1.Attributes.Add("data-upd-route", "GridWorker.aspx");
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        public void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("data-id", e.Row.DataItem.GetType().GetProperty("Id").GetValue(e.Row.DataItem, null).ToString());
                e.Row.Cells[1].Attributes.Add("data-col-name", "Name");
                e.Row.Cells[1].Attributes.Add("class", "bg-updatable");
            }
        }
