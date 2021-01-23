    private ObservableCollection<SubViewModel> _rows;
    public ViewModel()
    {
       //Initialize the sub view models
       _rows = new ObservableCollection<SubViewModel>();
       //Populate the list somehow
       foreach (var r in sourceOfRows)
       {
          _rows.Add(new SubViewModel(this));
       }
    }
    public ObservableCollection<SubViewModels> Rows
    {
      get 
      {
        return _rows;
      }
    }
      
