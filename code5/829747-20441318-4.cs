    public interface ICustomerFactory {
        IEnumerable<Customer> CreateCustomers(DataTable data);
    }
    public class CustomerFactory
    {
        public IEnumerable<Customer> CreateCustomers(DataTable data)
        {
             return (from DataRow row in data.Rows
                 select new Customer
                 {
                     Name = row[0].ToString(), Email = row[1].ToString()
                 }).ToList();
        }
    }
