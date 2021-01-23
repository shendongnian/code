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
    //prevent copy and past and delete pasted text
            private void card_No_TextChanged(object sender, EventArgs e)
        {
            if (card_No.Text.Length >0)
            {
                if (Regex.Matches(card_No.Text, @"(-|\d)").Count != card_No.Text.Length)
                {
                    if (!Clipboard.ContainsText()) return;
                    var txt = Clipboard.GetText();
                    if (card_No.Text.Contains(txt))
                    {
                        int ind = card_No.Text.IndexOf(txt, System.StringComparison.Ordinal);
                        var text = card_No.Text.Substring(0, ind);
                        card_No.Text = text;
                        MessageBox.Show(@"not allowed");
                    }
                    else if (txt.Contains(card_No.Text))
                    {
                        int ind = txt.IndexOf(card_No.Text, System.StringComparison.Ordinal);
                        var text = txt.Substring(0, ind);
                        card_No.Text = text;
                        MessageBox.Show(@"not allowed");
                    }
                }
            }
          
        }
