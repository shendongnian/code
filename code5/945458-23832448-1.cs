    public interface IDepartmentDataSource
    {
        IQueryable<Employee> Employees { get; }
        IQueryable<Department> Departments { get; }
        void Save();
    }
    public class TestClass : IDepartmentDataSource
    {
        public IQueryable<Employee> Employees
        {
            get { /* TODO: */}
        }
        public IQueryable<Department> Departments
        {
            get { /* TODO:  */ }
        }
        public void Save()
        {
            //TODO:
        }
    }
