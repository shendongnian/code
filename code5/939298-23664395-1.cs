        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = GetData();
            GridView1.DataBind();
        }
        private DataTable GetData()
        {
            // get some data and return it
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (HideCell(e.Row.RowIndex))
                {
                    var cell = e.Row.Cells.Cast<TableCell>().FirstOrDefault(c => c.FindControl("btnTest") != null);
                    if (cell != null)
                    {
                        cell.CssClass = "hidden";
                    }
                }
            }
        }
        private bool HideCell(int rowNum)
        {
            return rowNum%2 == 0;
        }
