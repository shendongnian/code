    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] =
                    this.Page.ClientScript.
                   GetPostBackClientHyperlink(this.grdList, "Select$" + e.Row.RowIndex);
            }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
            GridViewRow SelectedRow = grdList.SelectedRow;
            string id = SelectedRow.Cells[0].Text;
            Response.Redirect("~/Mail/ShowMail.aspx?q="+id);
    }
