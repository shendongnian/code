      public IEnumerable<ProductVM> GetAllProductList()
      {
        @using(DBContext context = new DBContext() ) 
        {
          return context.Produce.Select( p => new ProductVM () { Produce_Name = v.ProductName; Produce_Type = v.ProduceType;} ).ToList<>(ProductVM) ;
        }
      }
