    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {   //Adding link button to first column
            LinkButton lnkView = new LinkButton();
            lnkView.ID = "lnkView";
            lnkView.Text = "View";
            lnkView.Click += ViewDetails;
            lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row[selectedID].ToString();
            e.Row.Cells[0].Controls.Add(lnkView);
        }
    }
