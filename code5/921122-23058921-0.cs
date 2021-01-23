    protected void imgExpandSource_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgExpandSource = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)imgExpandSource
                                 // GridViewRowRow of gvSource
                                 .NamingContainer
                                 // gvSource
                                 .NamingContainer
                                 // GridViewRow of gvTest
                                 .NamingContainer;
        int x = gvrow.RowIndex;
    }
