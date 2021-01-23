    public interface ICustomersService
    {
        IEnumerable<ICustomer> ExistingCustomers { get; }
        IObservable<ICustomer> NewCustomers { get; }
        IObservable<ICustomer> Customers { get; }
    }
    public class CustomerService : ICustomerService
    {
        public IEnumerable<ICustomer> ExistingCustomers { get { ... } }
        public IObservable<ICustomer> NewCustomers { get { ... } }
        public IObservable<ICustomer> Customers
        {
            get
            {
               return this.ExistingCustomers.ToObservable().Concat(this.NewCustomers);
            }
        }
    }
