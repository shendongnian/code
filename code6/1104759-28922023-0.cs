    // Model stuff...
    public interface IBaseEntity
    {
        [Key]
        int Id { get; set; }
    }
    
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
    
        // Add some extra fields for all Models that use BaseEntity
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Last Modified")]
        public virtual DateTime LastModified { get; set; }
    
        [ConcurrencyCheck]
        [Timestamp]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual byte[] Timestamp { get; set; }
    }
    
    public class Person : BaseEntity
    {
        // Person Model here...
    }
    
    public class Employee : Person
    {
        // Extra Employee Model items here
    }
    
    public class Customer : Person
    {
        // Extra Customer Model items here
    }
    // End Model stuff
    
    // Repository stuff...
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int? id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Commit(); // To save changes rather than performing a save after each Add/Update/Delete etc.
    }
    
    public class EFRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        public virtual IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable<T>();
        }
        public virtual T GetById(int? id)
        {
            var item = DbSet.Find(id);
            return item;
        }
        public virtual T Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
            // SaveChanges() - removed from each DbSet, so can call on all changes in one transaction.
            // Using Unit Of Work Pattern. Can still use it here though if wished.
            return entity;
        }
        // And so on for each storage method.
    }
    
    public interface IEmployeeRepository: IRepository<Employee>
    public interface ICustomerRepository: IRepository<Customer>
    
    public class EmployeeRepository : EFRepository<Employee>, IEmployeeRepository
    public class CustomerRepository : EFRepository<Customer>, ICustomerRepository
    // End Repository stuff
