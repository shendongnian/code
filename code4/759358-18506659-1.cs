    public abstract HeadOffice<T> : IOffice
    where T : Employee
    {
         ObservableCollection<T> _employees = new ObservableCollection<T>();
         public ObservableCollection<Employee> Employees
          { 
              get
              {
                  return new ObservableCollection<Employee>(_employees);
              } 
              set
              {
                  _employees.Clear();
                  foreach (var e in value)
                  {
                      var t = e as T;
                      if (t == null)
                          throw new InvalidOperationException("...");
                      _employees.Add(t);
                  }
              } 
          }
    }
