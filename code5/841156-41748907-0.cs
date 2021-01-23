    private void ListBox1_MouseUp(object sender, MouseButtonEventArgs e)
    {
        ListBox lstBox = (ListBox)sender;
        ListBoxItem item = lstBox.SelectedItem;
        if (item != null)  // avoids exception when an empty line is clicked
        {
            blockNameList.Text = item.name;
            blockIdList.Text = item.id;
        }
    }
    
