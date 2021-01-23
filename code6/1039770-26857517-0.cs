    namespace Northwind.ServiceContracts
    {
        [ServiceContract(Name = "CustomerCartService",
            Namespace = "http://northwind.com/CustomerCartService",
            SessionMode=SessionMode.Required)]
        public interface ICustomerCartService
        {
            [OperationContract]
            bool AddProductsToCart(int productID);
        }
    }
    namespace Northwind.CustomerCartServices
    {
        [ServiceBehavior(Name = "CategoryService",
             Namespace = "http://northwind.com/CustomerCartService",
             InstanceContextMode=InstanceContextMode.PerSession )] 
        public class CustomerCartService : ICustomerCartService
        {
            public bool AddProductsToCart(int productID);
            {
                // code for adding product to customer cart.
                return true;
            }
        }
    }
