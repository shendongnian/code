    if (e.CommandName == "ARCHIVE") //FOR SETTING THE VIEW LINK BUTTON
    {
        GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
        LinkButton lnkbtn = (LinkButton)row.FindControl("lnkClick"); // LinkButton ID
        lnkbtn.Text = "viewed";
        lnkbtn.Enabled = false;
    }
