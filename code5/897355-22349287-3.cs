    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ComboBox1.SelectedItem.ToString().Contains("*"))
        {
            //Change color here
            ComboBox1.BackColor = Color.Red;
        }
    }
