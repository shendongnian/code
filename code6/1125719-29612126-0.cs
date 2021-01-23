        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                e.Handled = !char.IsDigit(e.KeyChar)&&(e.KeyChar != '.') && !char.IsControl(e.KeyChar);
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
              
             
            }
        }
 
