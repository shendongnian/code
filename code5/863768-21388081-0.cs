     public List<ProductModel> GetProducts (int CategoryId, int Start, int End, Func<IQueryable<ProductModel>, IOrderedQueryable<ProductModel>> order? = null)
     {
      //code shown in question
      if( order != null )
      {
       Products = order(Products).ToList();
      }
     }
