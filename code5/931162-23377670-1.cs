    decimal total = 0; //declare the total as global variable
    private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal subTotal = ReceiptBox.Items.Cast<Hardware>().Sum(item => item.Price);
            decimal tax = Math.Round((subTotal * .075M), 2);
            total = subTotal + tax;
            lblSub.Text = "$" + subTotal.ToString();
            lblTax.Text = "$" + tax.ToString();
            lblTotal.Text = "$" + total.ToString();
            lblSub.Visible = true;
            lblTax.Visible = true;
            lblTotal.Visible = true;
        }
     private void btnChange_Click(object sender, EventArgs e)
     {
         decimal customerPay = 100;
         if (total != 0){
                 decimal changeDue = customerPay - total;
         
                 txtDollar.Txt = "$ " + changeDue.toString();
                 MessageBox.Show("Change Due: " + txtDollar.Txt);
         }
     }
