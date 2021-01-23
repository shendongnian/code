    public class EmployeeSearchResult
    {
        public List<Employee> Employees{get;set;}
        public bool Success{get;set;}
    }
    private EmployeeSearchResult Search()
    {
        var employeeSearchResult = new EmployeeSearchResult();
        employeeSearchResult.Employees = new List<Employee>();
        employeeSearchResult.SearchSuccess = true;
        return employeeSearchResult;
    }
