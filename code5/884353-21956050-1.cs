    private void Button_Click(object sender, RoutedEventArgs e)
    {
        TreeViewItem SelectedTreeViewItem = SampleTreeView.SelectedItem as TreeViewItem;
        string FileName = "";
        if (SelectedTreeViewItem != null)
        {
            FileName = SelectedTreeViewItem.Header.ToString(); // Here
        }
        MessageBox.Show(FileName);
    }
