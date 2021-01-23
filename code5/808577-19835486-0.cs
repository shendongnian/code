    var folder = Package.Current.InstalledLocation.GetFolderAsync(Folder)
                                               .GetAwaiter()
                                               .GetResult();
    var file = folder.GetFileAsync(Filename).GetAwaiter().GetResult();
    var content = FileIO.ReadTextAsync(file).GetAwaiter().GetResult();
