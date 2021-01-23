    public class HumanResource
    {
        public IEnumerable<EmployeeModel> Employees
        {
            get; 
            private set;
        }
        public HumanResource()
        {
            // Although the property can be assigned in the CTor to prevent the null issue ...
            Employees = new List<EmployeeModel>();
        }
        private void AddProductiveEmployee()
        {
            // ... We need to continually cast within the class, which is just silly.
            (Employees as IList).Add(new EmployeeModel());
        }
