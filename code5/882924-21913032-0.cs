    private void nextButton_Click(object sender, EventArgs e)
            {
                ParseItems();                
            }
        public void ParseItems()
            {
                try
                {
                    Amount = decimal.Parse(DepositTextBox1.Text);
        
                    try
                    {
                        WeekInterestRate = decimal.Parse(WeekIntTextBox.Text);
                        try
                        {
                            TwoWeekInterestRate = decimal.Parse(TWeekIntTextBox.Text);
                            try
                            {
                                MonthInterestRate = decimal.Parse(MonthIntTextBox.Text);
                                try
                                {
                                    ThreeMonthInterestRate = decimal.Parse(ThreeMonthIntTextBox.Text);
                                    //here how you can achieve this 
                                     Formchange(); 
                                }
                                catch
                                {
                                    MessageBox.Show("Please enter values in numerical form", "Input Error");
                                    ThreeMonthIntTextBox.Focus();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Please enter values in numerical form", "Input Error");
                                MonthIntTextBox.Focus();
        
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Please enter values in numerical form","Input Error");
                            TWeekIntTextBox.Focus();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Please enter values in numerical form", "Input Error");
                        WeekIntTextBox.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("Please enter values in numerical form","Input Error");
                    DepositTextBox1.Focus();
                }
        
            }
