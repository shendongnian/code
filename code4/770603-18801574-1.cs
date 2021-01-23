     private void card_No_KeyPress(object sender, KeyPressEventArgs e)
            {
                var textBox = sender as TextBox;
                //handels integers, decimal numbers and OemMinus (-) character
                if (((!char.IsControl(e.KeyChar))
                     && (!char.IsDigit(e.KeyChar))
                     && (e.KeyChar != '-')
                    ) || (textBox != null
                          && (e.KeyChar != '.'
                              && (textBox.Text.IndexOf('.') > -1))))
                    e.Handled = true;
    
    
                if (e.Handled)
                    MessageBox.Show(@"not allowed");
            }
