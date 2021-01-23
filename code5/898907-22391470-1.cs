    double TotalPrice = 0;
    private void Total(object sender, EventArgs e)
    {
         if (CagesCheckBox.Checked)
         {
             TotalPrice += 0.75;
             TotalPriceTextBox.Text = TotalPrice.ToString();
         }
    }
