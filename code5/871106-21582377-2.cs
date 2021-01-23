    public int SelectedMonth
    {
        get 
        { 
            return _SelectedMonth; 
        }
        set 
        {
            if (_SelectedMonth != value)
            {
                 _SelectedMonth = value;
                 RaisePropertyChanged("SelectedMonth");
                 UpdateData(); // This private method updates BudgetEntries collection
            }
        }
    }
