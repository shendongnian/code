    // Service
    public async Task<int> GetImages(object queryParemeters,
        CancellationToken cancellationToken,
        IProgress<CustomFileInfoType> progress);
    // ViewModel
    var collection = new ObservableCollection<CustomFileInfoType>();
    var progress = new Progress<CustomFileInfoType>(x => collection.Add(x));
    await GetImages(query, token, progress);
