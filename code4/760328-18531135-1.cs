    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            Label myLabel = e.Row.FindControl("myLabelID") as Label;
            myLabel.Visible = false;
        }
    }
