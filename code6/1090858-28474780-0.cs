    public ObservableCollection<YourDataType> SomeCollectionPropertyInMainTemplateViewModel
    {
        get { return someCollectionPropertyInMainTemplateViewModel; }
        set
        {
            someCollectionPropertyInMainTemplateViewModel = value; 
            NotifyPropertyChanged("SomeCollectionPropertyInMainTemplateViewModel"); 
            NotifyPropertyChanged("NumberOfRecords"); 
        }
    }
    public int NumberOfRecords
    {
        get { return someCollectionPropertyInMainTemplateViewModel.Count; }
    }
