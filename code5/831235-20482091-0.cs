    static async Task<CameraGroup> GetItemGroupAsync(string uniqueId)
    {
        await _sampleDataSource.GetSampleDataAsync();
        var matches = _sampleDataSource.Groups
            .Where(group => group.Items.Any(item => item.Id.Equals(uniqueId)));
        return matches.Count() == 1 ? matches.First() : null;
    }
