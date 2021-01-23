    protected void dgBoundItems(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView rv = (DataRowView)e.Item.DataItem;
            if (rv.Row.ItemArray[2].ToString() == "Sign In")
            {
                e.Item.Cells[0].Attributes.Add("class", "signin");
            }
            else
            {
                e.Item.Cells[0].Attributes.Add("class", "signout");
            }
    
        }
    
    }
