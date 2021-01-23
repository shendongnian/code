    comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
    private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
            if (!comboBox1.Items.Contains(comboBox1.Text)) 
                 comboBox1.Items.Add(comboBox1.Text);
    }
