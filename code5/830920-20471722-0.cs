    private void btnAddBasket_Click(object sender, EventArgs e)
    {
        Product NewItem = null;
    
        foreach (Product tmp in tmpProducts)
        {
    		NewItem = new Product();
            NewItem.Stock = tmp.Stock;
            tmp.Quantity = NewItem.Quantity;
        }
        NewItem.Quantity = Convert.ToInt16(txtQuantity.Text);
    
        if (NewItem.Quantity > 0)
        {
            if (NewItem.Quantity > NewItem.Stock)
            {
                MessageBox.Show("There is only = " + NewItem.Stock + " in stock");
            }
            else
            {
                shoppingCart.Add(tmpProducts.ElementAt(lstViewProducts.SelectedIndex));
                LoadCart();
                txtQuantity.Text = "0";
            }
        }
        else
            MessageBox.Show("Please enter quantity you want");
    }
