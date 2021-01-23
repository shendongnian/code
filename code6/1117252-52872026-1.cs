    private void txtNum_TextChanged(object sender, EventArgs e)
    {
           if (txtNum.Text.Length > 0)
           {
                try
                {
                    Convert.ToDecimal(txtNum.Text);                  
                }
                catch (Exception exception)
                {
                    txtNum.Text = txtNum.Text.Remove(txtNum.TextLength - 1, 1);
                    txtNum.SelectionStart = txtNum.Text.Length; 
                    txtNum.SelectionLength = 0;
                }
            }
    }
