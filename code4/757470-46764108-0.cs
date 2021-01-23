    private void txtrate_TextChanged_1(object sender, EventArgs e)
            {
                double parsedValue;
                decimal d;
                // That Check the Value Double or Not
                if (!double.TryParse(txtrate.Text, out parsedValue))
                {
                    //Then Check The Value Decimal or double Becouse The Retailler Software Tack A decimal or double value
                    if (decimal.TryParse(txtrate.Text, out d) || double.TryParse(txtrate.Text, out parsedValue))
                    {
                        purchase();
                    }
                    else
                    {
                        //otherwise focus on agin TextBox With Value 0
                        txtrate.Focus();                  
                        txtrate.Text = "0";                   
                    }
    
    
                }
                else
                {
                    // that function will be used for calculation Like 
                    purchase();
                    /*  if (txtqty.Text != "" && txtrate.Text != "")
                      {
                          double rate = Convert.ToDouble(txtrate.Text);
                          double Qty = Convert.ToDouble(txtqty.Text);
                          amt = rate * Qty;
                      }*/
    
                }`enter code here`
            }
