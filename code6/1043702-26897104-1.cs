    public class CustomerRepository : ICustomerRepository
    {
        public void Insert(Customer customer)
        {
            using (var db = new DatabaseContext())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }    
        }
     
        ... and so on
    }
