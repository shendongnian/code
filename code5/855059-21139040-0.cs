    private IList<Employee> employees;
    public IList<Employee> Employees
    {
        get
        {
            return employees;
        }
    
        set
        {
            employees = value;
    
            foreach (var employee in employees)
            {
                employee.Position = this;
            }
        }
    }
