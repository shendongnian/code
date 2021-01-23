    public partial class Employee
    {
        public string EmployeeFullName
        {
            get
            {
                return string.Format("{0}, {1} ('{2}')", this.LastName, this.FirstName, this.SSN);
            }
        }
    }
