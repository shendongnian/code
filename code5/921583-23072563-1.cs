    private ListItem searchProvider;
    public ListItem SearchProvider
    {
        get { return searchProvider; }
        set
        {
            searchProvider = value;
            OnPropertyChanged();
        }
    }
