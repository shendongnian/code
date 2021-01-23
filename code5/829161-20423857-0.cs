    public class ProductBusiness
    {
      private readonly IProductDataAccess  _productDataAccess;
      
      public ProductBusiness(IProductDataAccess productDataAccess)
      {
          _productDataAccess = productDataAccess;
      }
      public bool CreateProduct(Product newProduct)
       {
        bool result=_productDataAccess.CreateProduct(newProduct);
        return result;
      }
    }
