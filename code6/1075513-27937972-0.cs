    private void txtboxSubTotal1_TextChanged_1(object sender, EventArgs e)
    {
        CalcGrandTotal();
    }
    
    private void txtboxSubTotal2_TextChanged_1(object sender, EventArgs e)
    {
        CalcGrandTotal();
    }
    
    private void CalcGrandTotal()
    {
       decimal grandTotal = 0;
       decimal parseValue= 0;
    
        if (!string.IsNullOrEmpty(txtboxSubTotal1.Text) and decimal.TryParse(txtboxSubTotal1.Text, parseValue))
            grandTotal  += parseValue;
    
        if (!string.IsNullOrEmpty(txtboxSubTotal2.Text) and decimal.TryParse(txtboxSubTotal2.Text, parseValue))
            grandTotal  += parseValue;
    
    txtboxGrandTotal.Text = grandTotal.ToString();
    }
