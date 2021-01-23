    private ICollectionView _employeeCollectionView;
    public ICollectionView EmployeeCollectionView
    {
      get { return _employeeCollectionView; }
      set
      {
        if (_employeeCollectionView != value)
        {
          if (_employeeCollectionView != null)
          {
            _employeeCollectionView.CollectionChanged -= EmployeeCollectionView_CurrentChanged;
          }
          _employeeCollectionView = value;
          _employeeCollectionView.CollectionChanged += EmployeeCollectionView_CurrentChanged;
          OnPropertyChanged("EmployeeCollectionView");
        }
        
      }
    }
    public EmployeeMasterViewModel(IEmployeeMasterView view, IUnityContainer container)
    {
      GetEmployee();      
    }
    private void EmployeeCollectionView_CurrentChanged(object sender, EventArgs e)
    {
      var currentEmployee = EmployeeCollectionView.CurrentItem as EmployeeMaster;
    }
