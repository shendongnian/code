    private void OnPropertyChanged(object sender, NotifyPropertyChangedEventArgs e)
    {
        PropertyChanged("TranslatedWithErrorsCount");
    }
    FileCollection.CollectionChanged += (sender, e) => 
    {
        PropertyChanged("TranslatedWithErrorsCount"); 
    
        if (e.NewItems != null)
        {
            foreach (var item in e.NewItems)
            {
                var inpc = item as INotifyPropertyChanged;
         
                inpc.PropertyChanged += OnPropertyChanged;
            }
        }
      
        if (e.OldItems != null)
        {
            foreach (var item in e.OldItems)
            {
                var inpc = item as INotifyPropertyChanged;
         
                inpc.PropertyChanged += (sender, e) => OnPropertyChanged;
            }
        }
    }
