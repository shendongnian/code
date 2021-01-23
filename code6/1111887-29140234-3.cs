    void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsDone")
                raisePropertyChanged("IsDone");
        }
