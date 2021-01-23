    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
    foreach (GridViewRow gvRow in GridView2.Rows)
    {
        Control ctrl = gvRow.FindControl("ddl_jd");
        DropDownList ddl = ctrl as DropDownList;
        if (ddl != null)
            ddl.SelectedIndex = DropDownList3.SelectedIndex;
    }
    }
