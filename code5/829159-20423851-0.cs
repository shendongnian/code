    public class ProductBusiness
    {
        IProductDataAccess Pda {get; set;}
    }
    
    var productBusiness = new ProductBusiness();
    productBusiness.Pda = new ProductDataAccess();
    productBusiness.Pda = new MockProductDataAccess();
