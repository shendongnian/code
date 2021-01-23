    public YourDataType SelectedItem
    {
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            NotifyPropertyChanged("SelectedItem");
            FilteredCollection = new ObservableCollection<YourDataType>(
    PrivateCollection.Where(i = i.SomeProperty == selectedItem.AnotherProperty).ToList());
        }
    }
