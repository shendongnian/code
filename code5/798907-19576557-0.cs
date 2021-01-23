    public class Employee
    {
        public string Name {get;set;}
        public int employee_id {get;set;}
        public int Age {get;set;}
    }
    
    public class EmployeeCollection : IEnumerable, IEnumerable<Employee>, IOrderedEnumerable<Employee>
    {
        public Func<Employee, object> SortOrder {get;set;}
        protected Dictionary<int,Employee> EmployeeById = new Dictionary<int,Employee>();
        public void Add(Employee ePassed)
        {
            EmployeeById[ePassed.employee_id] = ePassed;
        }
        public IEnumerator<Employee> GetEnumerator()
        {
            if (SortOrder == null)
                return EmployeeById.Values.GetEnumerator();
            else
                return EmployeeById.Values.OrderBy(SortOrder).GetEnumerator();
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
