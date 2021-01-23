    public SelectedDate
    {
        set
        {
          _selectedDate = value;
          ReferentialDate = value.AddDays(-1);
          RaisePropertyChanged("SelectedDate");          
        }
    }
