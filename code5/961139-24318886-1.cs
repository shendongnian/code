    public class StarringViewModel
    {
        public StarringViewModel
        {
            employeeNames = new List<string>();
        }
        ...
        ...
        public IEnumerable<string> employeeNames { get; private set; }
        public string EmployeeNamesString
        {
            get { return string.Join(", ", employeeNames); }
        }
    }
