    private bool PlayerWantsToPurchase(Property property)
    {
       var message = String.Format("You have landed on {0}. This property costs ${1}. Would you like to purchase it?", 
                                   property.Name, property.Price);
    
       var result = MessageBox.Show(message, "Purchase Property?", MessageBoxButtons.YesNo);
       return result == DialogResult.Yes;
    }
