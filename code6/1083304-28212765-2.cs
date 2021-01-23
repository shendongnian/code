        var transactions = new List<Transaction>
        {
            new Transaction { Buyer = new Buyer { UserID = 1 } },
            new Transaction { Buyer = new Buyer { UserID = 2 } },
            new Transaction { Buyer = new Buyer { UserID = 3 } },
            new Transaction { Buyer = new Buyer { UserID = 1 } },
            new Transaction { Buyer = new Buyer { UserID = 3 } }
        };
        var result = transactions.
            Select(o => o).
            GroupBy(o => new
            {
                UserId = o.Buyer.UserID
            },
            (key, items) => new
            {
                //UserId = key.UserId,
                Transactions = items.Select(p => p).ToList()
            }).
            ToList();
