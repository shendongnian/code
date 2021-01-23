    protected void gvproducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToUpper() == "PURCHASE")
        {
            MPEPurchase.Show();
        }
    }   
