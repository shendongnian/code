        public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
    }
    public interface IUnitOfWork
    {
        T GetById<T>(int id) where T : new() ;
    }
    public class UnitOfWork : IUnitOfWork
    {
        // Implementation of IUnitOfWork
        //public T GetById<T>(int id) where T: new();
        //{
        //    return new T();
        //}
    }
    
    public class EmployeeRepository : IEmployeeRepository
    {
        //You are injecting Unit Of Work here
        public IUnitOfWork UnitOfWork { get; set; }
        public Employee GetById(int id)
        {
            // Making call to database here;
            return UnitOfWork.GetById<Employee>(id);
        }
    }
