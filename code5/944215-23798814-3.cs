    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Display the company name in italics.
            Label lblAssignto = (Label)e.Row.FindControl("lblassignto");
            LinkButton addevent = (LinkButton)e.Row.FindControl("lnkBtnAddEvent");
            LinkButton showevent = (LinkButton)e.Row.FindControl("lnkBtnShowEvent");
            if (string.IsNullOrEmpty(lblAssignto.Text))
            {
                addevent.Visible = false;
                showevent.Visible = false;
            }
            else
            {
                addevent.Visible = true;
                showevent.Visible = true;
            }
        }
    }
