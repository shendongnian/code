    public bool IsCurrentlyDownloading = false;
    bool isWorking = false;
    
    private async void assetThumbnail_Tapped(object sender, TappedRoutedEventArgs e)
    {
        if(!isWorking)
            await OpenOrDownload();
    }
    
    private async Task OpenOrDownload()
    {
        isWorking = true;
    
        if (FileIsDownloaded == true)
        {
            string filename = Util.GetLocalFileName(CustomerAsset.file.id, "CustomerAssetFile");
            var options = new Windows.System.LauncherOptions();
            options.DisplayApplicationPicker = false;
            var sampleFile = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            await Windows.System.Launcher.LaunchFileAsync(sampleFile, options);
        }
        else
        {
            if (!IsCurrentlyDownloading)
            {
                IsCurrentlyDownloading = true;
                DownloadFiles();
            }
        }
    
        isWorking = false;
    }
