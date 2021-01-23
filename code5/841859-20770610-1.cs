    private void txtRate_TextChanged()
    {
       try   
      {
        if(txtRate.Text.Trim() == string.Empty) return;
        decimal qty;   
        decimal price;   
        decimal amt = 0;   
        qty = Convert.ToDecimal(txtQuantity.Text);  
        price = Convert.ToDecimal(txtRate.Text);  
        amt = qty * price;  
        txtAmount.Text = amt.ToString();    
      }   
      catch (Exception ex)   
      {   
        MessageBox.Show(ex.Message);   
      }
    }
