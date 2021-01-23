    public class Account {
      public int? Id {get;set;}
      public string Name {get;set;}
      public string Address {get;set;}
      public string Country {get;set;}
      public int ShopId {get; set;}
      public Shop Shop {get;set;}
    }
    public class Shop {
      public int? ShopId {get;set;}
      public string Name {get;set;}
      public string Url {get;set;}
    }
 
    var resultList = conn.Query<Account, Shop, Account>(@"
                    SELECT a.Name, a.Address, a.Country, a.ShopId
                            s.ShopId, s.Name, s.Url
                    FROM Account a
                    INNER JOIN Shop s ON s.ShopId = a.ShopId                    
                    ", (a, s) => {
                         a.Shop = s;
                         return a;
                     },
                     splitOn: "ShopId"
                     ).AsQueryable();
