    private void Print_Click(object sender, EventArgs e)
    {
        string selectedItem = this.ComboBox_Lang.GetItemText(this.ComboBox_Lang.SelectedItem);
        Printer p = new Printer(selectedItem);
        p.Show();
    }
