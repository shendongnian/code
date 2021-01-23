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
                if (card_No.Text.Length<1) return;
                if (new Regex(@"(-|\d)").IsMatch(card_No.Text)) return;
                if (!Clipboard.ContainsText()) return;
                var txt = Clipboard.GetText();
                if (!card_No.Text.Contains(txt)) return;
                var ind = card_No.Text.IndexOf(txt, StringComparison.Ordinal);
                var text = card_No.Text.Substring(0, ind);
                card_No.Text = text;
                MessageBox.Show(@"not allowed");
            }
