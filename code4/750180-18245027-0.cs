    [WebMethod]
    public static string GetProducts()
    {
      // instantiate a serializer
      JavaScriptSerializer TheSerializer = new JavaScriptSerializer();
            
      //optional: you can create your own custom converter
      TheSerializer.RegisterConverters(new JavaScriptConverter[] {new MyCustomJson()});
                    
      var products = context.GetProducts().ToList();   
              
      var TheJson = TheSerializer.Serialize(products);
            
      return TheJson;
    }
