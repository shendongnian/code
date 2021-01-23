     private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //bold checkbox is changed
            if (checkBox1.Checked && checkBox2.Checked)
            {
                textBox1.Font = new Font("Arial", 12, ((FontStyle)((FontStyle.Bold | FontStyle.Underline))));
            }
            else if (checkBox1.Checked)
            {
                textBox1.Font = new Font("Arial", 12, FontStyle.Bold);
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //unerline checkbox is changed
            if (checkBox1.Checked && checkBox2.Checked)
            {
                textBox1.Font = new Font("Arial", 12, ((FontStyle)((FontStyle.Bold | FontStyle.Underline))));
            }
            else if (checkBox2.Checked)
            {
                textBox1.Font = new Font("Arial", 12, FontStyle.Bold);
            }
        }
