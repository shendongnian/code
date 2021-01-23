    int ordered;
    if(!int16.TryParse(txtQtyOrdered.Text, out ordered))
    {
        MessageBox.Show("Invalid number for Ordered quantity");
        return;
    }
    int orderID;
    if(!int16.TryParse(txtPONumber.Text, out orderID))
    {
        MessageBox.Show("Invalid number for OrderId");
        return;
    }
    int itemID;
    if(!int16.TryParse(txtItemNo.Text, out itemID))
    {
        MessageBox.Show("Invalid number for ItemID");
        return;
    }
