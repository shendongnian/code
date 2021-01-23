    protected void ddlcat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcat.SelectedItem.Text == "Other...")
        {
            Response.Redirect("ManageCat-SubCat.aspx?Register=pnlCat");
        }
    }
    
    protected void ddlsubcat_SelectedIndexChanged(object sender, EventArgs e)
    
    {
        if (ddlsubcat.SelectedItem.Text == "Other...")
        {
            Response.Redirect("ManageCat-SubCat.aspx?Register=pnlSubCat");
    
        }
    
    }
