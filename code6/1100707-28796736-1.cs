    public class Group : IEnumerable<Employee>
    {
        public string Text { get; set; }
        public List<Employee> Employees { get; set; }
        public IEnumerator<Employee> GetEnumerator()
        {
            return Employees.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
