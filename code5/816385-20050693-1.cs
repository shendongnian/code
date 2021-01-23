    private InventoryItem item;
    public InventoryItem Item 
    { 
        get 
        {
            return item; 
        }
        set 
        { 
            item = value;
            lblItemNumber.Text = item.Item.ItemNumber;
            lblTitle.Text = item.Item.Title;
            lblModel.Text = item.Item.Model;
            lblPrice.Text = item.Item.Price.ToString();
        }
    }
