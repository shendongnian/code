    private void CreateDepartment()
    {
        if(Department.Error!=null)
        {
           ValidationErrors = Department.Error;
           RaisePropertyChanged("validationErrors");
           return;
        }
       
        bool success = departmentService.SaveDepartment(_department);
    }
