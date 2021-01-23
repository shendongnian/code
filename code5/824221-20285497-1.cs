    class Customer
    {
        private List<Product> Products { get; set; }
        public void AddProduct(Product product)
        {
           Products.Add(product);
           if(!product.CustomersWhoBoughtThis.Contains(this))
               product.CustomersWhoBoughtThis.Add(this);
        }
    
        public void RemoveProduct(Product product)
        {
           Products.Remove(product);
           if(product.CustomersWhoBoughtThis.Contains(this))
               product.CustomersWhoBoughtThis.Remove(this);
        }
        public IEnumerable<Product> GetProducts()
        {
           return Products;
        }
    }
