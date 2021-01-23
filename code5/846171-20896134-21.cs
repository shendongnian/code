    string selection = null;
    private void ComboBox1_SelectedIndex(object sender, EventArgs e)
    {
        if (ComboBox1.SelectedIndex!=-1)
        {
            selection = ComboBox1.SelectedItem.ToString();
        }
    }
