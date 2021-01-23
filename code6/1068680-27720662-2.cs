    public class HumanResource
    {
       private readonly IList<EmployeeModel> _employees = new List<EmployeeModel>();
       public IEnumerable<EmployeeModel> Employees
       {
         get
         {
             return _employees;
         }
         // No Setter - callers may only enumerate the collection
      }
    }
