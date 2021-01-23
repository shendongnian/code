    private void buttoncredit_Click(object sender, RoutedEventArgs e)
    {
        double newAmount;
        if(!double.TryParse(textboxamount.Text, out newAmount))
        {
            // The input is wrong - handle that
            MessageBox.Show("Please enter a valid amount");
            textboxamount.Focus();
            return;
        }
        totalamount += newAmount;
        balance1 = "Your Balance is: £";
        label2 = balance1 + totalamount;
        // .. Your code...
