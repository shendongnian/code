    // Form1
    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedItem = (sender as ComboBox).SelectedItem.ToString();
    }
    private void button_Click(object sender, EventArgs e)
    {
        var frm2 = new Form2() { Owner = this };
        frm2.Show();
    }
    public string SelectedItem { get; private set; }
