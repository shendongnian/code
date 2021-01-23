    // the handler for CollectionChanged for the INNER collection (PunchDetailModels)
    private void handler(object sender, NotifyCollectionChangedEventArgs e)
          {
            base.RaisePropertyChanged(PunchDetailModelsPropertyName); // If you don't have a method with such signature in ObservableObject (one that takes a string and raises PropertyChanged for it) you'll have to write it.
            base.RaisePropertyChanged("InOutCount")
            base.RaisePropertyChanged("FirstCheckIn")
            base.RaisePropertyChanged("LastCheckOut")
            // and so on for all the properties that need to be refreshed
           }
