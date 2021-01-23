    public ObservableCollection<Plant> Plants
    {
        get 
        {
            return _plants;
        }
        set 
        {
             _plants = value;
             OnPropertyChanged();
        }
    }
