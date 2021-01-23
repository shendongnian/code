    private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           button1.Enabled = (checkBox1.CheckState == CheckState.Checked);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
