    public string SelectedTitle
    {
        get { return selectedTitle; }
        set 
        {
            selectedTitle = value; 
            NotifyPropertyChanged("SelectedTitle");
            ViewModel = ViewModelCollection.Where(v => v.Title == SelectedTitle);
        }
    }
