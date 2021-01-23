    public class ProductCount {
       public int ProductType {get; set;}
       public int Count {get; set;}
    }
    
    var ProductCountList = db.Fetch<ProductCount>(@"SELECT DISTINCT productType, 
            COUNT(*) as Count 
            FROM Products 
            GROUP BY productType");
