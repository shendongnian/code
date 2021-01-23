    private decimal totalamount = 0;
    public string balance1;
    private void buttoncredit_Click(object sender, RoutedEventArgs e)
    {
        decimal temp;
        if(decimal.TryParse(textboxamount.Text, out temp))
        {
            totalamount = totalamount + temp;
            balance1 = "Your Balance is: ";
            label2.Content = balance1 + totalamount.ToString("C");    
            textboxamount.Clear();
        }
        else
            MessageBox.Show("Not a valid amount");
    }
    private void buttondebit_Click(object sender, RoutedEventArgs e)
    {
        decimal temp;
        if(decimal.TryParse(textboxamount.Text, out temp))
        {
            if (totalamount - temp < 0)
            {
                 MessageBox.Show("Overdraft Limit is not set please contact Customer Services");
            }
            else
            {
                 totalamount = totalamount - temp;
                 balance1 = " Your Balance is: ";
                 label2.Content = balance1 + totalamount.ToString("C");
                 textboxamount.Clear();
            }
        }
        else
            MessageBox.Show("Not a valid amount");
    }
