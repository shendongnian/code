    private ObservableCollection<DiscoveredComputer> _NetworkedComputersResults;
    public ObservableCollection<DiscoveredComputer> NetworkedComputersResults { 
        get { return _NetworkedComputersResults; }
        set
        {
            _NetworkedComputersResults = value;
            NotifyPropertyChanged("NetworkedComputersResults");
        }
    }
