    private InventoryItem item;
    public InventoryItem Item 
    {
        get 
        { 
            return this.item; 
        }
        set 
        { 
            this.item = value;
            lblItemNumber.Text = value.Item.ItemNumber;
            lblTitle.Text = value.Item.Title;
            lblModel.Text = value.Item.Model;
            lblPrice.Text = value.Item.Price.ToString();
        }
    }
