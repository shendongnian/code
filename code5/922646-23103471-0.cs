    protected void GridView_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (Set condition here)
        {
            MyGridView.Columns[1].Visible = false;
            MyGridView.Columns[2].Visible = false;
        }
    }
