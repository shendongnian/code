    public interface ICustomerRepo { }
    public interface IEmployeeRepo {  }
    public abstract class PersonRepoBase<T> {  }
    public class CustomerRepo : PersonRepoBase<Customer>, ICustomerRepo { }
    public class EmployeeRepo : PersonRepoBase<Employee>, IEmployeeRepo { }
