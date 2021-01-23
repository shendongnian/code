    protected void lnkButton_Click(Object sender, EventArgs e)
    {
        LinkButton lnkButton = (LinkButton)sender;
        String index = lnkButton.ID.Substring(lnkButton.ID.Length - 1);
        Panel tempPanel = new Panel();
        GridView grv = (GridView)tempPanel.FindControl("grid_view" + index);
        grv.Visible = true;
    }
    
