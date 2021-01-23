    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                
                if(this.checkBox1.Checked)
                {
                    //Allow only number
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }            
            }
