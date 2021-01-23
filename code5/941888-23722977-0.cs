    public class Employee
    {
    
        public int Id { get; set; }
        public string FullName { get; set; }
    }
    // Now using this we will have a simple context class.
    public class HRContext : DbContext
    {        
    
        public DbSet<DomainClasses.Employee> Employees { get; set; }
    }
    
    // After that, define the repository interface IEmployeeRepository.
    public interface IEmployeeRepository : IDisposable
    {
        IQueryable<Employee> All { get; }
        IQueryable<Employee> AllAsync { get; }
        IQueryable<Employee> AllIncluding(params Expression<Func<Employee, object>>[] includeProperties);
    
        Employee Find(int id);
        Employee FindAsync(int id);
        void InsertOrUpdate(Employee employee);
        void Delete(int id);
        void Save();
    }
    
    // Then the Repository class called EmployeeRepository. 
    public class EmployeeRepository : IEmployeeRepository
    {
        HRContext context = new HRContext();
    
        public IQueryable<Employee> All
        {
            get { return context.Employees; }
        }
    
            public IQueryable<Employee> AllIncluding(params Expression<Func<Employee, object>>[] includeProperties)
            {
            IQueryable<Employee> query = context.Employees;
    
            foreach (var includeProperty in includeProperties)
            {
                   query = query.Include(includeProperty);
            }
    
            return query;
    
        }
    
        public Employee Find(int id)
        {
            return context.Employees.Find(id);
        }
    
        public void InsertOrUpdate(Employee employee)
        {
            if (employee.Id == default(int)) {
    
                // New entity
                context.Employees.Add(employee);
    
            } else {
    
                // Existing entity
                context.Entry(employee).State = EntityState.Modified;
            }
        }
    
        public void Delete(int id)
        {
            var employee = context.Employees.Find(id);
            context.Employees.Remove(employee);
        }
    
        public void Save()
        {
            context.SaveChanges();
        }
    
        public void Dispose() 
        {
            context.Dispose();
        }
    
    }
