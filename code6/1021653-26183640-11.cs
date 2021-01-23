    private async Task<IEnumerable<Music>> getMusic(IStorageFolder rootFolder)
    {
        var properties = await new[] { rootFolder }
            .TraverseAsync(folder => folder.GetFoldersAsync())
            .SelectManyAsync(folder => folder.GetFilesAsync())
            .SelectManyAsync(file => file.GetMusicPropertiesAsync());
        return properties.Select(prop => new Music());
    }
