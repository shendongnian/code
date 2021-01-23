    public class MyViewModel
    {
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
    
        public void GetCustomerName(int customerId) 
        {
           CustomerName = CustomerServiceLayer.GetCustomerName(customerId);
           // CustomerService Layer (I.e. a repository that contains this info;
        }
        public void GetProductName(int productId) 
        {
           ProductName = ProductServiceLayer.GetProductName(productId); 
           // ProductService Layer (I.e. a repository that contains this info;
        }
        
    }
