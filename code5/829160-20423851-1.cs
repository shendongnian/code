    public class ProductBusiness
    {
        private readonly IProductDataAccess _pda;
        public ProductBusiness(IProductDataAccess pda)
        {
            _pda = pda;
        }
    }
    
    var productBusiness = new ProductBusiness(new ProductDataAccess());
    var productBusiness = new ProductBusiness(new MockProductDataAccess());
