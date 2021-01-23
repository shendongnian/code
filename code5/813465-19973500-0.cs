    protected void RepeaterItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            string serviceAmount = DataBinder.Eval(e.Item.DataItem, "SERVICE_AMOUNT").ToString();
    
            var priceTextBox = e.Item.FindControl("priceTextBox") as TextBox;
            var lblServiceAmount = e.Item.FindControl("lblServiceAmount") as Label;
    
            priceTextBox.Visible = serviceAmount != "-";
            lblServiceAmount.Visible = !priceTextBox.Visible;
    
        }
    }
