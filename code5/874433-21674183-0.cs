    private void comboBoxCell_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox conboBox = (ComboBox)sender;
        int index = conboBox.SelectedIndex;
        if (index > -1)
        {
            label1.Text = conboBox.SelectedValue + ": " + conboBox.Text;
        }
    }
