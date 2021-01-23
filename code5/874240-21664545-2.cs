    private void checkBox1_Click(object sender, EventArgs e)
    {
        checkBox1.Checked = !checkBox1.Checked;
        if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0)
        {
            if (UserConfirmedWarning("Numbers will be lost"))
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                checkBox1.Checked = true;
            }
        }
        if (!checkBox1.Checked)
            DisablePreceedingCheckboxes();
        SetLineTextboxesEnabled(checkBox1.Checked);
    }
