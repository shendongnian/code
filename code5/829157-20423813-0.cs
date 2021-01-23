    public class ProductBusiness
    {
        private IProductDataAccess _productDataAccess;    
    
        public ProductBusiness(IProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }
    
        public bool CreateProduct(Product newProduct)
        {
            _productDataAccess.CreateProduct(newProduct);
            return result;
        }
    }
