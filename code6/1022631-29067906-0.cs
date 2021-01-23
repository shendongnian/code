    protected void Product_PKRadComboBox_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
    {
        if (e.EndOfItems && e.NumberOfItems==0)
        {
            var addItem = new RadComboBoxItem("Add a new product...", "addnewproduct");
            addItem.ToolTip = "Click to create a new product...";
            addItem.CssClass = "UseSpecialCSSStyling";
            Product_PKRadComboBox.Items.Add(addItem);
        }
    }
