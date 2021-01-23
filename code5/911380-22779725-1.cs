     protected void grdEvent_RowDeleted(object sender, GridViewEditEventArgs e)
    {
       if(e.Exception == null)
    {
        UpdateLabels();
    }
    }
