    private async void ButtonPlay_Click(object sender, RoutedEventArgs e)
    {
        MediaElement snd = new MediaElement();
        StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync("Sounds");
        StorageFile file = await folder.GetFileAsync("Alarm01.wav");
        var stream = await file.OpenAsync(FileAccessMode.Read);
        snd.SetSource(stream, file.ContentType);
        snd.Play();
        this.Frame.Navigate(typeof(Game));
    
     }
