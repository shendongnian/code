    static async Task<CameraGroup> GetItemGroupAsync(string uniqueId)
    {
        await _sampleDataSource.GetSampleDataAsync();
        return _sampleDataSource.Groups
            .SingleOrDefault(group =>
                            group.Items.Any(item => item.Id.Equals(uniqueId)));
    }
