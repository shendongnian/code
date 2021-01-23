    public ObservableCollection<SaleryDetailsModel> SaleryDetailsCollection
    {
        get { return _SaleryDetailsCollection; }
        set
        {
            _SaleryDetailsCollection = value;
            SalaryTotal = SaleryDetailsCollection.Sum(x => x.Amount); // This line must be after the field assignment.
            NotifyPropertyChanged("SaleryDetailsCollection");
        }
    }
