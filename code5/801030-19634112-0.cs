    private void ListView_MouseDClick(object sender, MouseButtonEventArgs e)
    {
        Listview_data lvd = null;
        lvd = DocsListView.SelectedItem as Listview_data;
        if (lvd == null)
        {
            return;
        }
        
        MessageBox.Show(lvd.name);
    }
