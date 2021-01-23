    public class EmployeeSearchDTO:SearchDTO<Employee>
    {
        
        public override IList<Employee> SearchResults { get; set; }
    }
