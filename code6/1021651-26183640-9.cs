    private async Task<IEnumerable<Music>> getMusic(IStorageFolder rootFolder)
    {
        var folders = await new[] { rootFolder }
            .TraverseAsync(folder => folder.GetFoldersAsync());
        var files = (await Task.WhenAll(
            folders.Select(folder => folder.GetFilesAsync())))
            .SelectMany(folder => folder);
        var properties = (await Task.WhenAll(
            files.Select(file => file.GetMusicPropertiesAsync())))
            .SelectMany(property => property);
        return properties.Select(prop => new Music());
    }
