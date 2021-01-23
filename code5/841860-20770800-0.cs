    private void txtRate_TextChanged(object sender, EventArgs e)   
    {
      try   
      {   
          decimal qty;   
          decimal price;   
          decimal amt = 0;
          if (!String.IsNullOrEmpty(txtQuantity.Text) && !String.IsNullOrEmpty(txtRate.Text))
          {
              qty = Convert.ToDecimal(txtQuantity.Text);  
              price = Convert.ToDecimal(txtRate.Text);  
              amt = qty * price;  
              txtAmount.Text = amt.ToString();    
          }     
      }   
      catch (Exception ex)   
      {   
          MessageBox.Show(ex.Message);   
      }   
    }
