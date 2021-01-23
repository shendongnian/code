    protected void gvContents_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[3].Text.Contains("Special"))
            {
                //set The "Special" word only forecolor to red
                e.Row.Cells[3].Text = e.Row.Cells[3].Text.Replace("Special", "<span class='special'>Special</span>");
            }
        }
    }
