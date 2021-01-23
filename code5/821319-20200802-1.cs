    private void newBalance()
    {
       double numberEntered ;
       double balance ; 
       if(double.TryParse(txtWithdraw.Text,System.Globalization.NumberStyles.None,System.Globalization.CultureInfo.InvariantCulture,out numberEntered))
       {
         if(double.TryParse(txtBalance.Text,System.Globalization.NumberStyles.None,System.Globalization.CultureInfo.InvariantCulture,out balance))
         {
            double newBalance = balance - numberEntered;
            txtBalance.Text=((balance - numberEntered).ToString());
    
            if (numberEntered < 1 || numberEntered > 9999999)
            {
                MessageBox.Show("You must enter a number between 1 and 10");
            }
    
            else
            MessageBox.Show(String.Format(numberEntered.ToString()), "You have withdrawn");
            txtWithdraw.Text = "";
            // MessageBox.Show(newBalance.ToString(),numberEntered.ToString());
         }
       }
    }
