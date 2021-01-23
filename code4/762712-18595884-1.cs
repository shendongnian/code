    FileSetting selectedItem;
    private void lstViewFolderSettings_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedItem = lstViewFolderSettings.SelectedItem as FileSetting;
        txtFolder.Text = selectedItem.FolderPath;
        txtType.Text = selectedItem.Name;
        txtXPath.Text = selectedItem.XPath;
        
        lstViewFolderSettings.UnselectAll();
    }
