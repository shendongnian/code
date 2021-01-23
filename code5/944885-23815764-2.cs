            var merge2 = customers.GroupJoin(balances,
                c => c.CustomerNumber,
                b => b.CustomerNumber,
                (c, b) => new
                {
                    custname = c.CustomerNumber,
                    custamount = b.ToList()
                });
            foreach (var cust in merge2)
            {
                Console.WriteLine("Customer {0} has following amounts: ", 
                    cust.custname);
                foreach (var amount in cust.custamount)
                {
                    Console.WriteLine(amount.Amount);
                }
            }
