    public int SelectedItem
    {
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            NotifyPropertyChanged("SelectedItem");
            UpdateFilteredItems();
        }
    }
    ...
    private void UpdateFilteredItems()
    {
        FilteredItems = 
            new ObservableCollection<YourDataType>(Items.Take(SelectedItem));
    }
