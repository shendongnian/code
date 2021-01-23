     private void TextBoxCostKeyPress(object sender, KeyPressEventArgs e)
            {
                try
                {
                    if (!char.IsControl(e.KeyChar)
            && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                  
                   
                }
                catch (Exception ex)
                {
                    ExceptionkeeperBll.LogFileWrite(ex);
                }
            }
    
            private void TextBoxCostTextChanged(object sender, EventArgs e)
            {
                try
                {
                      string value = TextBoxCost.Text.Replace(",", "");
          ulong ul;
          if (ulong.TryParse(value, out ul))
          {
              TextBoxCost.TextChanged -= TextBoxCostTextChanged;
              TextBoxCost.Text = string.Format("{0:#,#}", ul);
              TextBoxCost.SelectionStart = TextBoxCost.Text.Length;
              TextBoxCost.TextChanged += TextBoxCostTextChanged;
          }
                }
                catch (Exception ex)
                {
                    ExceptionkeeperBll.LogFileWrite(ex);
                }
            }
