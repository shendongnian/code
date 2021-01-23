    private async void SearchFolder_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        button.IsEnabled = false;
        string searchPath = textBlock1.Text, searchText = textBox1.Text;
        Settings.Default.PreviousSearchText = searchText;
        Settings.Default.Save();
        List<PortableDeviceFolder> folders = new List<PortableDeviceFolder>();
        PortableDeviceFolder rootFolder = new WindowsDirectoryFolder(searchPath);
        progressBar1.Value = 0;
        progressBar1.Maximum = await Task.Run(() => CountFolders(rootFolder));
        await Task.Run(() => SearchFolder(rootFolder, folders, searchText));
        listBox1.ItemsSource = folders;
        button.IsEnabled = true;
    }
