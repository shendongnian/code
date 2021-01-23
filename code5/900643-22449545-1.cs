    protected void GVCities_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
    
                ImageButton imgbtnDelete = e.Row.FindControl("imgbtnDelete") as ImageButton;
                imgbtnDelete.OnClientClick = "return confirm('Are you sure you want to delete " +  
                                             GVCities.DataKeys[e.Row.RowIndex]["Cities"].ToString() + " city?');";
            }
        }
        catch (Exception ex)
        {
           ...
        }
    }
