    public CreateDepartmentViewModel(IDepartmentService DepartmentService)
    {
        departmentService = DepartmentService;        
        _department = new DepartmentViewModel(new Department());
        this.CreateDepartmentCommand = new RelayCommand(CreateDepartment, CanExecute);
    
        _department.PropertyChanged += (s,a) => 
        {
           ValidationErrors = Department.Errors;
           RaisePropertyChanged("ValidationErrors");
           this.CreateDepartmentCommand.RaiseCanExecuteChanged();
        }  
    }
    
    public DepartmentViewModel Department
    {
        get
        {
            return _department;
        }
        set
        {
            if (_department == value)
            {
                return;
            }
            _department = value;
            RaisePropertyChanged("Department");
        }
    }
    
    public string ValidationErrors {get; set;}
    
    private Boolean CanExecute()
    {
        return string.IsNullOrEmpty(ValidationErrors);
    }
