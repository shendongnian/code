    private string _searchText
    public string SearchText
    {
        get{...}
        set
        {
            if(_searchText != value)
            {
                _searchText = value;
                RunSearch();
            }
    
    }
    
    public ObservableCollection<...> SearchResults { get; set; }
    
    private void searchThreadCompleted(results)
    {
        SearchResults = results;
    }
