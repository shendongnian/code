    private void ListView_MouseDClick(object sender, MouseButtonEventArgs e)
    {
        SimpleCube.Documents lvd = null;
        lvd = DocsListView.SelectedItem as SimpleCube.Documents;
        if(lvd != null)
            MessageBox.Show(lvd.Name);
    }
