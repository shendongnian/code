    public List<ServiceJobItem> Items { get; private set; }
    
    void UpdateItems() {
    	Items = new List<ServiceJobItem>(repVReportsDataSource.GetJobItems().Where(_predicate));
    	OnPropertyChanged("Items");
    }
