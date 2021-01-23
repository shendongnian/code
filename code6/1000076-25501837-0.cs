    public class MainService : IProductService, IMainService
    {
      MainService mMain = new MainService();
      ProductService mProduct = new ProductService();
    
      public void ImplementedMainServiceFunction()
      {
        mMain.DoSomething();
      }
    
      public void ImplementedProductServiceFunction(string s)
      {
        if (!string.IsNullOrEmpty(s))
          mProduct.DoSomething();
      }
    }
