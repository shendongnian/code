    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        TextBox1.Text = ((DataRowView)ListBox1.SelectedItem).Row.ItemArray[0].ToString();
        // bind the ComboBox as well
    }
