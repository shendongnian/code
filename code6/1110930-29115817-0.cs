    public ObservableCollection<Plant> Plants
    {
        get 
        {
            return _plants;
        }
        get 
        {
             _plants = value;
             OnPropertyChanged();
        }
    }
