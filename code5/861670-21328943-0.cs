    double? discount = null;
    
    if (!String.IsNullOrEmpty(txtDiscount.Text))
    {   
       double value;
       if (!Double.TryParse(txtDiscount.Text, out value))
       {
           errors.Add("Discount must be a double.");
           return;
       }
                  
       discount = value;
    }
