    private ObservableCollection<EmployeeViewModel> _employees;
    public ObservableCollection<EmployeeViewModel> Employees 
    {
        get { return _employees; }
        set
        {
        	_employees = value;
        	RaisePropertyChanged();
        }
    }
