    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if(radioButton_1.Checked)
        {
             comboBox1.Items.Remove("google");
             comboBox1.Items.Add("yahoo");
        }
        else
        {
             comboBox1.Items.Remove("yahoo");
             comboBox1.Items.Add("google");
        }
    }
