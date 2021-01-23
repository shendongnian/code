     private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                maskedTextBox1.Mask = "000-000-0000";
            }
            else
            {
                maskedTextBox1.Mask = null;
            }
        }
