    void myObservableCollection_CollectionChanged(
            Object sender, NotifyCollectionChangedEventArgs e){
       if (PropertyChanged != null)
       {
           PropertyChanged(this, new PropertyChangedEventArgs("SelectionProperty"));
       }
    }
