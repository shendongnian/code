    void OnCarSelectedPropertyChanged(object sender, PropertyChangedEventArgs e)    
    {
        if (e.PropertyName == "CarCategory")
        {
            NotifyPropertyChanged("ExtraCarDetailsVisibility");
        }
    }
