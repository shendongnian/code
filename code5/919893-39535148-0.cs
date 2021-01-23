    private void MyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox cbx = sender as ComboBox;
        string myValue = ((DataRowView)cbx.Items.GetItemAt(cbx.SelectedIndex))).Row.ItemArray[0].ToString();
    }
