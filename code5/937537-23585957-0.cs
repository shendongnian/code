    // Here we are assuming that my item collection is of type Person.
    private Person _selectedItem;
    public Person SelectedItem
    {
        get { return _selectedItem; }
        set
        {
            if (_selectedItem == value)
            {
                return;
            }
            _selectedItem = value;
            OnPropertyChanged("SelectedItem");
            }
    }
