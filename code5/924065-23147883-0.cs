    protected void sizeDropdown_SelectedIndexChanged(object sender, EventArgs e)
    {
        
       double amount = 0;
       if (sizeDropdown.SelectedItem.Equals("50g"))
       {
          amount = 4.99;
       }
       else if (sizeDropdown.SelectedItem.Equals("100g"))
        {
           amount = 7.99;
        }
       else if (sizeDropdown.SelectedItem.Equals("150g"))
       {
          amount = 9.99;
       }
          priceLabel.Text = amount.ToString();
    }
