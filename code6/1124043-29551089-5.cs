    async Task readAllFiles(StorageFolder folder)
    {
        var files =await folder.GetFilesAsync();
        foreach (var file in files)
        {
            test.Add(file.Name);
        }
    
        var folders = await folder.GetFoldersAsync();
        foreach (var child in folders)
            await readAllFiles(child);
    }
    
    
    public async void buttonTest()
    {
        test.Clear();
        StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;
        var folders = await externalDevices.GetFoldersAsync();
        foreach (var folder in folders)
        {
            await readAllFiles(folder);
        }
        CoreDispatcher dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            foreach (string name in test)
            {
                Button button1 = new Button();
                button1.Height = 75;
                button1.Content = name;
                button1.Name = name;
    
                testStackPanal.Children.Add(button1);
            }
        });
    }
