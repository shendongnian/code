    public DataTable LoadData()
    {
        DataTable dtAdditionsDetails = ...
        // Get your data here synchronously
        return dtAdditionsDetails;
    } 
    public async Task<DataTable> LoadDataAsync()
    {
        DataTable dtAdditionsDetails = LoadData();
        return Task.Run(() => LoadData());
    } 
...
    public async void GetDataAsynchronously()
    {
        DataTable dtAdditionsDetails = await LoadDataAsync();
    } 
