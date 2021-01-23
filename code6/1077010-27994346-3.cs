    private async void SearchFolder_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        button.IsEnabled = false;
        string searchPath = textBlock1.Text, searchText = textBox1.Text;
        List<PortableDeviceFolder> folders = new List<PortableDeviceFolder>();
        PortableDeviceFolder rootFolder = new WindowsDirectoryFolder(searchPath);
        progressBar1.Value = 0;
        progressBar1.Maximum = await Task.Run(() => CountFolders(rootFolder));
        Progress<int> progress =
            new Progress<int>(increment => progressBar1.Value += increment);
        await Task.Run(() => SearchFolder(rootFolder, folders, searchText, progress));
        listBox1.ItemsSource = folders;
        button.IsEnabled = true;
    }
