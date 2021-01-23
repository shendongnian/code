       public static string Parse<Tenum>(this object spr, int id) where Tenum : struct, IConvertible 
       {
           Contract.Ensures(typeof(Tenum).IsEnum, "type must be is enum");
           return ((Tenum)(object)id).ToString();
    
       }
      
     string ProductTypeTitle =  this.Parse<ProductType>(product.ProductTypeID);
