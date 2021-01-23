    public class Employee
    {
        public string Name {get;set;}
        public int employee_id {get;set;}
        public int Age {get;set;}
    }
    
    public class EmployeeCollection : IEnumerable, IEnumerable<Employee>, IOrderedEnumerable<Employee>
    {
        public Func<Employee, object> SortOrder {get;set;}
        public Func<Employee, bool> Filter {get;set;}
        protected Dictionary<int,Employee> EmployeeById = new Dictionary<int,Employee>();
        public void Add(Employee ePassed)
        {
            EmployeeById[ePassed.employee_id] = ePassed;
        }
        public IEnumerator<Employee> GetEnumerator()
        {
            var employees = EmployeeById.Keys.Select(id => this.GetEmployee(id));
            if (Filter != null)
                employees = employees.Where(Filter);
            if (SortOrder != null)
                employees = employees.OrderBy(SortOrder);
            return employees.GetEnumerator();
        }
        public Employee GetEmployee(int id)
        {
            return EmployeeById[id];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
          return this.GetEnumerator();
        }
        public IOrderedEnumerable<Employee> CreateOrderedEnumerable<TKey>(Func<Employee, TKey> KeySelector, IComparer<TKey> comparer, bool descending)
        {
          throw new NotImplementedException();
        }
    }
    // this is some code you might use to test this:
    var EmployeeCollection = new EmployeeCollection
    {
        new Employee { employee_id = 1, Age = 20, Name = "Joe" },
        new Employee { employee_id = 2, Age = 30, Name = "Thomas" },
        new Employee { employee_id = 3, Age = 25, Name = "Robert" },
    };
    EmployeeCollection.SortOrder = x => x.Age;
    EmployeeCollection.Filter = x => x.Name.Length > 4;
    foreach (Employee e in EmployeeCollection)
    {
        // do something
    }
