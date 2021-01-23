    var query =  from c in db.Customers
                         join b in db.Banks on c.Id equals b.CustomerId
                         join bt in db.BankTransactions on b.Id equals bt.BankId                         
                         group new { bt.MoneyIn,bt.MoneyOut} by c.Name into Cust                         
                         select new
                         {
                             Name = Cust.Key,
                             Balance = Cust.Sum(x=>x.MoneyIn) - Cust.Sum(x=>x.MoneyOut) 
                         };
