    private void Button_Click(object sender, RoutedEventArgs e)
    {
        TreeViewItem MyTreeViewItem = treeView1.SelectedItem as TreeViewItem;
        if (MyTreeViewItem != null)
        {
            MessageBox.Show(MyTreeViewItem.Header.ToString());
        }
    }
