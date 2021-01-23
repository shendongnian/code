    private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                MessageBox.Show("You are playing "+radioButton1.Text);
            }
    
            else if (radioButton2.Checked)
            {
                MessageBox.Show("You are playing Maplestory "+"+radioButton2.Text);
            }
    
            else if (radioButton3.Checked)
            {
                MessageBox.Show("You are playing League "+"+radioButton3.Text);
            }
        }
