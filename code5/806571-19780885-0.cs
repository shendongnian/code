    public List<ListBoxPersonExample> ListBoxItems { get; set; }
            
    public ListBoxPersonExample SelectedPerson
    {
        get { return _selectedPerson; }
        set { _selectedPerson = value; RaisePropertyChanged("SelectedPerson");}
    }
