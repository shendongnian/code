    try
    {
        priceData = double.Parse(txtPR.Text);
        qty = double.Parse(txtQty.Text);
        answer = priceData * qty;
        Subtotal += answer;
        lblTotal.Text = "You have to pay " + Subtotal.ToString();
        MessageBox.Show("You have to pay a total of:" + Subtotal.ToString());
        writeFile();
        DialogResult result = MessageBox.Show("Do you want to buy other products?", "BUY", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if(result == DialogResult.No)
        {
            Subtotal = 0;
            MessageBox.Show("Thank you for shopping! Kindly get your receipt.");
            System.Diagnostics.Process.Start(@"c:\Add\Receipt.txt");
        }
    }
