    public class HumanResource
    {
       private readonly IList<EmployeeModel> _employees = new List<EmployeeModel>();
       public IEnumerable<EmployeeModel> Employees
       {
         get
         {
             return _employees;
         }
         // No Setter, or private setter - callers may only enumerate the collection
      }
    }
