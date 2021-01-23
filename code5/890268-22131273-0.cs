    public class MyRepository : IWhateverRepository
    {
        // ...
        public Customer GetCustomerByName(string customerName)
        {
            using (var db = new MyContext())
            {
                var customer = db.Customers.Where(cust => cust.Name == customerName).SingleOrDefault();
                return customer;
            }
        }
    
        public Customer StoreCustomer(Customer customer)
        {
            using (var db = new MyContext())
            {
                db.Entry(customer).State = customer.ID == 0 ? EntityState.Added : EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
