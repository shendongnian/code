    public interface IEmployeeRepository 
    {
       Employee GetEmployeeById(int id);
    }
    
    public class FakeEmployeeRepository : IEmployeeRepository 
    {
       public Employee GetEmployeeById(int id)
       {
         return new Employee { ... };
       }
    }
