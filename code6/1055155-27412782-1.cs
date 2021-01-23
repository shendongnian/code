    public BindingList<Product> YourQueryCall()
    {
      BindingList<Product> products = new BindingList<Product>();
      /*
       *  Your code to query the db.
       */
      while reader.Read()
      {
        Product existingProduct = new Product();
        int id = // value from the reader
        string name = // value from the reader
        double version = // value from the reader
        try
        {
          existingProduct = products.Single(p => p.ID == id && p.Name == name);
          existingProduct.Version.Add(version);
        }
        catch // No product yet exists for this id and name.
        {
          existingProduct.ID = id;
          existingProduct.Name = name;
          existingProduct.Version.Add(version);
          products.Add(existingProduct);
        }
      }
      return products;
    }
