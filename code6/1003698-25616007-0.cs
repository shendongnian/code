    protected void grdList_SelectedIndexChanged(object sender, EventArgs e)
    {
            GridViewRow SelectedRow = grdList.SelectedRow;
            string id = SelectedRow.Cells[0].Text;
            Response.Redirect("~/Mail/ShowMail.aspx?q=" + id);
    }
    protected void grdList_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            e.Row.ToolTip = "Click to select row";
            e.Row.Attributes["onclick"] =
                this.Page.ClientScript.
               GetPostBackClientHyperlink(this.grdList, "Select$" + e.Row.RowIndex);
        }
    }
