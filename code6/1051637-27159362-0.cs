    private double subTotal = 0.0;
    private void btn_click(Object sender,EventArgs e)
    {
       if (lstBoxItemSelection.Text =="Item 1 = 1.00")
       { 
            LstBoxSummary.Items.Add("Item 1 = 1.00")
            subTotal += 1.00;
       }
       if (lstBoxItemSelection.Text =="Item 2 = 2.00"  )
       { 
            LstBoxSummary.Items.Add("Item 2 = 2.00")
            subTotal += 2.00;
       }
    
       this.txtBoxSubTotal.Text = subtotal.ToString();
    }
