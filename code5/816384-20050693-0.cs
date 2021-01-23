    public InventoryItem Item 
    { 
        get 
        {
            return Item; // <-- "recursive" getter
        }
        set 
        { 
            Item = value; // <-- "recursive" setter
            lblItemNumber.Text = Item.Item.ItemNumber;
            lblTitle.Text = Item.Item.Title;
            lblModel.Text = Item.Item.Model;
            lblPrice.Text = Item.Item.Price.ToString();
        }
    }
