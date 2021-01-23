    var merge = customers.GroupJoin(balances, 
                c => c.CustomerNumber, 
                b => b.CustomerNumber,
                (c, b) => new
                {
                    custname = c.CustomerNumber, 
                    custamount = b.Sum(b2 => b2.Amount)
                });
    
                foreach (var cust in merge)
                {
                    Console.WriteLine("{0}: {1}", cust.custname, cust.custamount);
                }
