    private async void btnWrite_Click(object sender, RoutedEventArgs e)
    {
        await WriteToFile();
        // Update UI.
        this.btnWrite.IsEnabled = false;
        this.btnRead.IsEnabled = true;
    }
    private async Task WriteToFile()
    {
        // Get the text data from the textbox. 
        byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(this.textBox1.Text.ToCharArray());
        // Get the local folder.
        StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
        // Create a new folder name DataFolder.
        var dataFolder = await local.CreateFolderAsync("DataFolder",
        CreationCollisionOption.OpenIfExists);
        // Create a new file named DataFile.txt.
        var file = await dataFolder.CreateFileAsync("DataFile.txt",
        CreationCollisionOption.ReplaceExisting);
        // Write the data from the textbox.
        using (var s = await file.OpenStreamForWriteAsync())
        {
            s.Write(fileBytes, 0, fileBytes.Length);
        }
    }
