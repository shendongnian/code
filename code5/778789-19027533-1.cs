    public Product GetById(long id)
    {
       Product product;
       string storageKey = string.Format("products_{0}",id.ToString());
       product = (Product)HttpContext.Current.Cache.Get(storageKey);
       if (product == null)
       {
          product = _productContext.Products.Find(id);
          HttpContext.Current.Cache.Insert(storageKey, product);
       }
       else
       {
           _productContext.Products.Attach(product);
       }
       return product;
    }
