    public class Transaction
    {
        public Buyer Buyer { get; set; }
    }
    public class Buyer
    {
        public int UserID { get; set; }
    }
    [TestMethod]
    public void Test()
    {
        var t1 = new Transaction { Buyer = new Buyer { UserID = 1 } };
        var t2 = new Transaction { Buyer = new Buyer { UserID = 2 } };
        var t3 = new Transaction { Buyer = new Buyer { UserID = 3 } };
        var t4 = new Transaction { Buyer = new Buyer { UserID = 1 } };
        var t5 = new Transaction { Buyer = new Buyer { UserID = 3 } };
        var tList1 = new List<Transaction> { t1, t2, t3 };
        var tList2 = new List<Transaction> { t4, t5 };
        var tLists = new List<List<Transaction>> { tList1 , tList2};
        var result = tLists.
            SelectMany(o => o).
            GroupBy(o =>  new 
            {
                UserId = o.Buyer.UserID
            },
            (key, items) => new
            {
                UserId = key.UserId,
                Transactions = items.Select(p => p).ToList()
            }).
            ToList();
    }
