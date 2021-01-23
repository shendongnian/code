    public class Employee
    {
    	public Employee()
    	{
    		EmployeeDetails = new EmployeeDetails();
    		EmployeeDetails.EmpID = 123;
    		EmployeeDetails.EmpName = "ABC";
    	}
    
    	public EmployeeDetails EmployeeDetails { get; set; }
    }
