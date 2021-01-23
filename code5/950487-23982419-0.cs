    private void btnCalculate_Click(object sender, EventArgs e)
    {
        decimal subtotal;
        
        if (!decimal.TryParse(txtSubtotal.Text, out subtotal))
        {
            //Display some warning to the user
            MessageBox.Show(txtSubtotal.Text + " is not a valid number");
           
            //don't continue processing input
            return;
        }
        //input is good, continue processing
        decimal discountPercent = .25m;
        decimal discountAmount = Math.Round(subtotal * discountPercent,2);
        decimal invoiceTotal = Math.Round(subtotal - discountAmount,2);
    }
