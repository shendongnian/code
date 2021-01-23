    protected void ProjectsTBL_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = ProjectsTBL.SelectedRow;
        if (row.RowIndex >= ProjectsTBL.Rows.Count - 1) { return; }
        GridViewRow selectedRow = ProjectsTBL.Rows[row.RowIndex + 1];
        row.RowState = DataControlRowState.Normal;
        selectedRow.RowState = DataControlRowState.Selected;
        Session["selectedrow"] = selectedRow;
        Response.Redirect("ProjectDetails.aspx");
    }
