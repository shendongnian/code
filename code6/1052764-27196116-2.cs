    public class MyViewModel 
    {
        public Customer MyCustomer { get; set; }
        public Product MyProduct { get; set; }
        public MyViewModel(ICustomer customer, IProduct product) 
        {
           MyCustomer = customer;
           MyProduct = product;
        }
    }
