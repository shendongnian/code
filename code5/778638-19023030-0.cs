    private void _mmdButton_Click(object sender, EventArgs e)
            {
                var value = Convert.ToInt32(_mmdTextBox.Text);
    
                if (value > 1999)
                {
                    MessageBox.Show("Value is too high");
                }
                else if (value < 0)
                {
                    MessageBox.Show("Value is too low");
                }
                else
                {
                    MessageBox.Show("Value is ok");
                }
            }
