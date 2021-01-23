    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboBox1.Items.Remove(comboBox1.SelectedItem);
    
        if (comboBox1.Items.Count == 0)
            MessageBox.Show("All Gone!");
    }
