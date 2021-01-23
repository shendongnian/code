    public class EmployeeSearchDTO:SearchDTO<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override IList<Employee> SearchResults { get; set; }
    }
