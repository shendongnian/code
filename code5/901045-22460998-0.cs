    var contact = from c in Contact
                  group c by c.RegisterDate into c
                  select new StatusData
                  {
                    Date = c.Key,
                    RegisteredUsers = c.Count(),
                    Orders = 0,
                    Import = 0,
                  };
    
    var purchases = from p in Purchases
                    group p by p.PurchaseDate into p
                    select new StatusData
                    {
                      Date = p.Key,
                      RegisteredUsers = 0,
                      Orders = p.Count(),
                      Import = p.Sum(x => x.Import),
                    };
    
    var final = from x in contact.Concat(purchases)
                group x by x.Date into x
                select new StatusData
                {
                  Date = x.Key,
                  RegisteredUsers = x.Sum(y => y.RegisteredUsers),
                  Orders = x.Sum(y => y.Orders),
                  Import = x.Sum(y => y.Import),
                 };
