    [ServiceContract]
    public interface IService
    {
        [WebInvoke(Method = "POST", UriTemplate = "/ModifyCustomer", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Customer ModifyCustomer(Customer customer);
    }
    public class Service : IService
    {
        public Customer ModifyCustomer(Customer customer)
        {
            customer.Age += 1;
            return customer;
        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
