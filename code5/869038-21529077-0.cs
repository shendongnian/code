    if(gvDistribution.SelectedRow != null)
    {
        if (deliveryDate > DateTime.Today)
        {
            Label lblError = (Label)gvDistribution.SelectedRow.FindControl("lblError");
            lblError.Text = "Delivery date has not reach yet!";
        }
        else
        {
            // ...
        }
    }
             
