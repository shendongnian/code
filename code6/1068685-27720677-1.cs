    public class HumanResource
    {
        // This is the real employees that gets returned when its not null
        private IEnumerable<EmployeeModel> employees; // may be null
        // This is the empty IEnumerable that gets returned when employees is null
        private static readonly IEnumerable<EmployeeModel> EmptyEmployees =
            new EmployeeModel[0];
        public IEnumerable<EmployeeModel> Employees
        {
            get
            {
                return employees ?? EmptyEmployees;
            }
            set {};
        }
    }
