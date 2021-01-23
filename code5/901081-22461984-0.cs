    void GridViewFeedback_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        GridViewRow gvr = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        Button btnUp = e.FindControl("BtnLike_Click");
        Button btnDown = e.FindControl("btnDislike_Click");
        if(e.CommandName == "VoteUp")
        {
            btnUp.Enabled = false;
            btnDown.Enabled = true;
        }
        else if(e.CommandName == "VoteDown")
        {
            btnUp.Enabled = true;
            btnDown.Enabled = false;
        }
    }    
