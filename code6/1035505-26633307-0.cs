    public MyViewModel()
    {
        FileInfoCollection = new ObservableCollection<MyFileInfo>();
    
        // Hook up initial changed handler. Could also be done in setter
        FileInfoCollection.CollectionChanged += FileInfoCollection_CollectionChanged;
    }
    
    void FileInfoCollection_CollectionChanged(object sender, CollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach(MyFileInfo item in e.NewItems)
            {
                item.PropertyChanged += MyFileInfo_PropertyChanged;
            }
        }
    
        if (e.OldItems != null)
        {
            foreach(MyFileInfo item in e.OldItems)
            {
                item.PropertyChanged -= MyFileInfo_PropertyChanged;
            }
        }
    }
    
    void MyFileInfo_PropertyChanged(object sender, PropertyChange e)
    {
        // Whenever a FileInfo changes, raise change notification for collection
        RaisePropertyChanged("FileInfoCollection");
    }
