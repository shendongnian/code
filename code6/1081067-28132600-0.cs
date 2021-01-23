    class Order()
    {
      static Order instance;
    
      int orderId {get;set;}
      double total {get;set;}
      public Order()
      {
        if (instance != null)
          instance.Unload();
        instance = this;
      }
      ...
      public Unload()
      {
      }
    }
