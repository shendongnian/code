    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
        if ((numericUpDown1.Value > 0) && //or some verification on your input variable
            ((radioButton1.Checked == true) || (radioButton2.Checked == true)))
        {
            button1.Enabled = true;
        }
        else
        {
            button1.Enabled = false;
        }
    }
