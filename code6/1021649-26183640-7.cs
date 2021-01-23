    private async Task<IEnumerable<Music>> getMusic(IStorageFolder folder)
    {
        var folders = await new[] { folder }.TraverseAsync(f => f.GetFoldersAsync());
        var files = await folders.SelectManyAsync(f => f.GetFilesAsync());
        var properties = await files.SelectManyAsync(f => f.GetMusicPropertiesAsync());
        return properties.Select(prop => new Music());
    }
