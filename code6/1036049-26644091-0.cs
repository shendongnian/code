    private void numbersTB_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (sender as TextBox != null)
                {
                    if (char.IsDigit(e.KeyChar))
                        button1.Enabled = true;
                    else
                        button1.Enabled = false;
                }
            }
