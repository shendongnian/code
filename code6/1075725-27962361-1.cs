    private async void btn1_Click(object sender, RoutedEventArgs e)
    {
        var file = await Windows.Storage.KnownFolders.MusicLibrary.GetFileAsync("Addicted.mp3");
        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
        myMediaElement.SetSource(stream, file.ContentType);
    }
