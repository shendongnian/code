    public static DependencyProperty EmployeesProperty = DependencyProperty.Register(
        "Employees", typeof(ObservableCollection<Employee>), typeof(YourUserControl));
    public ObservableCollection<Employee> Employees
    {
        get { return (ObservableCollection<Employee>)GetValue(EmployeesProperty); }
        set { SetValue(EmployeesProperty, value); }
    }
