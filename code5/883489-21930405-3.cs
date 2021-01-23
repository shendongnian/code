    protected void onGridViewDataBound()
    {
        foreach(GridViewRow gvr in grd)
            if((gvr.FindControl("Label1") as Label).Text == "Complete")
            {
                (gvr.FindControl("Label1") as Label).Visible = true;
                (gvr.FindControl("HyperLink1") as HyperLink).Visible = false;
            }
    }
