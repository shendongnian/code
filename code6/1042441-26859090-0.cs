    public async Task OpenResearchAsync(string path)
    {
        if (path.ToLower().StartsWith("http://"))
        {
            await Launcher.LaunchUriAsync(new Uri(path));
        }
        else
        {
            IStorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            IStorageFile file = await folder.GetFileAsync(path);
            await Launcher.LaunchFileAsync(file);
        }
    }
