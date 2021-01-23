    private ValidDepartment _department = new ValidDepartment ();
    public ValidDepartment Department
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
