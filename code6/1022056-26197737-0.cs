     public static List<Client> GetClientsWithTotalOrders()
        { 
           //create DataContext object, use it, discard it:
            using (CodeProjectDataContext db = new GetDataContext())
            {
                //join Client with Order:
                var res = db.Clients  // db is the data context
                    .Join(
                    db.Orders,
                    o => o.ID,
                    c => c.ClientID,
                    (c, o) => new { c }
                    )
        
                    //group by Client
                    .GroupBy(o => o.c)
        
                    //define output object
                    .Select(o => new { ID = o.Key.ID, AddressID = o.Key.AddressID, 
                    Name = o.Key.Name, TotalOrders = o.Count() }) 
                   // here you won't select an anonymous type,
                  // you will select o => new CartProduct { Count = o.Count(), 
                  // Product = new Product { // map your properties } }
                    //output to List of objects:
                    .ToList()
                    ;
        
                 //cast the output sequence to List of Clients and return:
                 return (List<Client>)res;
            }
        };
