    private void chkDisable_CheckedChanged(object sender, EventArgs e)
    {
            if (((CheckBox)sender).Checked)
            {
                textBox1.Enable=true;
            }
            else
            {
                textBox1.Enable=false;
            }
    }
