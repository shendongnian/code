    public ObservableCollection<NotationVM> NotationVMs
    {
        get { return _notationVMs; }
        set 
        { 
            if (_notationVMs != null)
            {
                _notationVMs.CollectionChanged -= OnNotationVMsCollectionChanged;
            }
            _notationVMs = value;
            if (_notationVMs != null)
            {
                _notationVMs.CollectionChanged += OnNotationVMsCollectionChanged;
            } 
            NotifyPropertyChanged("NotationVMs"); 
            NotifyPropertyChanged("ReversedNotationVMs");
        }
    }
   
    private void OnNotationVMsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
         NotifyPropertyChanged("ReversedNotationVMs");
    }
