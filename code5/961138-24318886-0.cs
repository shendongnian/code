    public IEnumerable<string> employeeNames { get; set; }
    public string EmployeeNamesString
    {
        get { return string.Join(", ", this.employeeNames); }
    }
