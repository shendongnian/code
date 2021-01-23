    protected void ProductRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        Label output = (Label)item.FindControl("outputLabel");
        Product product = (Product)item.DataItem;
        if (product.Rank > 5 && product.X != null && product.Y != null)
        {
            output = "I want show this div just if my if statement is True";
        }
        else
        {
            output = product.Name;
        }
    }
