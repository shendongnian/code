    public void Multiply()
        {
            try
            {
    
                double vat = Convert.ToDouble(TextBox24.Text);
                double tot = Convert.ToDouble(TextBox21.Text);
                double ans = tot * vat;
    
                    //TextBox22.Text = ans.ToString().Trim(); 
                    TextBox22.Text = ans.ToString().Trim();
            }
            catch (Exception e)
            {
                TextBox22.Text = e.Message;
            }
    
        }
