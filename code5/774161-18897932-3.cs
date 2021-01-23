    public class EmployeesDataGrid : DataGrid
    {
        public static readonly DependencyProperty EmployeesProperty =
            DependencyProperty.Register("Employees", typeof(ObservableCollection<Employee>), typeof(EmployeesDataGrid), new PropertyMetadata(new ObservableCollection<Employee>()));
        public ObservableCollection<Employee> Employees
        {
            get { return (ObservableCollection<Employee>)GetValue(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }
    }
