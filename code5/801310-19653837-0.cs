     private void ValidateText(TextBox textbox)
            {
                int value;
    
                bool isConverted = Int32.TryParse(textbox.Text.Trim(), out value);
                if (!isConverted)
                {
                    MessageBox.Show("Only numbers allowed");
                    return;
                }
    
                if (value < 1 || value > 24)
                {
                    MessageBox.Show("Please enter a value between 1-24");
                }
            }
Validating txtHour by invoking above method
    ValidateText(txtHour);
