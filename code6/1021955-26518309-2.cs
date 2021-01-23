    public class WebsiteRegistry : Registry
    {
        public WebsiteRegistry()
        {
            For<ICustomerService>().Use<CustomerService>();
            For<IProductServer>().Use<ProductService>();
        }
    }
    
