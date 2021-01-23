       public abstract class Product 
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductCode { get; set; }
            public int ProductCatagoryId { get; set; }
        
            public abstract void AddProduct(params object[] arguments);
            
        }
