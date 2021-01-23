    private async Task<IEnumerable<Music>> getMusic(IStorageFolder folder)
    {
        var folders = await new[] { folder }.TraverseAsync(f => f.GetFoldersAsync());
        var files = (await Task.WhenAll(
            folders.Select(f => f.GetFilesAsync())))
            .SelectMany(f => f);
        var properties = (await Task.WhenAll(
            files.Select(f => f.GetMusicPropertiesAsync())))
            .SelectMany(p => p);
        return properties.Select(prop => new Music());
    }
