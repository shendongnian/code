    using (var db = new DbMain())
    {
         var q = from c in db.Customers
                 select c.Accounts;
         System.Diagnostics.Debug.Print(q.ToList()[0].AccountID);
    }
