    private void card_No_KeyPress(object sender, KeyPressEventArgs e)
            {
                //handel nmubers and OemMinus (-) character
                if ((!char.IsControl(e.KeyChar )) 
                    && (!char.IsDigit(e.KeyChar))
                    && (e.KeyChar != '-'))
                    e.Handled = true;
    
                var textBox = sender as TextBox;
    
                //handel decimal numbers just if you allow them 
                if (textBox != null && (e.KeyChar != '.'&&(textBox.Text.IndexOf('.') > -1)))
                {
                    e.Handled = true;
                }
                
            }
