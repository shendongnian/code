    public class YourClass : INotifyPropertyChanged //Note this INotifyPropertyChanged
    {
        private ObservableCollection<Employee> _myListOfEmployeeObjects;
        public ObservableCollection<Employee> ObservableEmployees
        {
            get
            {
                if (_myListOfEmployeeObjects == null) LoadEmployees();
                return _myListOfEmployeeObjects;
            }
            set
            {
                _myListOfEmployeeObjects = value;
                OnPropertyChanged("ObservableEmployees");
            }
        }
         private void LoadEmployees()
        {
            // Necessary stuff to load employees
            ObservableEmployees = new ObservableCollection<Employees>();
            ....
        }
