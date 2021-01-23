    public ObservableCollection<data> Source2 { get; private set; }
 
    public Data SelectedValue
    {
        get { return _selectedValue; }
        set
        {
            if (_selectedValue == value) return;
            _selectedValue = value;
            PopulateSource2();
        }
    }
 
    private void PopulateSource2()
    {
        Source2.Clear();
        //Get your other data from DB here
        Source2.Add(SelectedValue);//This is just to show that it works
    }
