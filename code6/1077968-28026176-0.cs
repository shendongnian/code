    var User = from d in Users
               select new UserDTO
               {
                   User = d,
                   Categories = (from t in Transactions
                                 where t.UserId == d.Id
                                 group t by t.Category into g   // <-- group by category
                                 select new CategoryDTO
                                 {
                                     Category = g.Key,
                                     Transactions = from ct in g
                                                     select new TransactionDTO
                                                     {
                                                         Id = ct.Id,
                                                         Quantity = ct.Quantity
                                                     }).ToList()
                                 }).ToList()
               };
    return User.ToList();
