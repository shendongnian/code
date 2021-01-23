    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (textBox1.Text.Trim() == "")
                    {
                    MessageBox.Show("Empty");
                    textBox1.Focus();
                     }
               else 
               textBox2.Focus();
                
            }
        }
