    var customers = new List<Customer>();
                var banks = new List<Bank>();
                var bankTransactions = new List<BankTransaction>();
    
                var result = from c in customers
                    join b in banks on c.Id equals b.CustomerId
                    join bt in bankTransactions on b.Id equals bt.BankId                         
                    group bt by c.Name into Cust
                    select new { Name = Cust.Key, Balance = Cust.Sum(x => x.MoneyIn) - Cust.Sum(x => x.MoneyIn) };
