    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public List<Employee> Employees
        {
           get
           {
               return this.employees;
           }
           set
           {
              this.employees = value;
              this.OnPropertyChanged("Employees");
           }
        }
        
        ...    
    }
