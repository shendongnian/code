    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    button1.PerformClick();
                    e.Handled = true;
                }
            }
