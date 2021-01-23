    private string _lastValue = string.Empty;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if
                    (checkBox1.Checked)
                {
                    _lastValue = label1.Text;
                    label1.Text = textBox1.Text + label1.Text;
                }
                else
                    label1.Text = _lastValue;
            }
        }
