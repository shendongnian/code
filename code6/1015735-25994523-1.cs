    public IPerson SelectedPerson
    {
        get {...}
        set
        {
            this._selectedPerson=value;
            this.MySummary = SummaryTabViewModel(_selectedPerson);
            OnPropertyChanged("SelectedPerson");
        }
      }
     public ISummaryTabViewModel MySummary 
     {
        get {...}
        set
        {
            this._mySummary = value;
            OnPropertyChanged("MySummary");
        }
     }
