    public interface ICustomerRepository
    {
       public List<Employee> GetAllEmployees();
    }
    
    public class CustomerRepository : ICustomerRepository
    {
       private _dbCrudApplicationContext db;
    
       public CustomerRepository(_dbCrudApplicationContext context)
       {
         db = context;
       }
    
       public List<Employee> GetAllEmployees()
       {
          return db.Employees.ToList();
       }
    }
