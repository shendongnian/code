    private static object _lock = new object();
          
    public MainWindowViewModel()
    {
        // ...
        _matchObsCollection = new ObservableCollection<EfesBet.DataContract.GetMatchDetailsDC>();
        BindingOperations.EnableCollectionSynchronization(_matchObsCollection , _lock);
    } 
