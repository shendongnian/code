    comboBox1.Items.Add(1);
    comboBox1.Items.Add(2);
    comboBox1.Items.Add(3);
    private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
    {
        //this will set what gets displayed in the combobox, but does not change the value.
        e.Value = "display value";
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        MessageBox.Show((sender as ComboBox).SelectedItem.ToString());
    }
