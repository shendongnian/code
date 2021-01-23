    [WebMethod]
    public static List GetProducts()
    {
       var products  = context.GetProducts().ToList();   
       return products;
    }
