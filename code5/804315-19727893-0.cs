    namespace A
    {
        public class B
        {
           string productIdStr1 = Request.QueryString["productID"];
         }
    }
    }
    public IQueryable<Product> GetProduct() 
      {
        int? productId;
        string productIdStr =productIdStr1  ;
        if (productIdStr != null)
            productId = int.Parse(productIdStr);
        else
            productId = null;
    
        }
