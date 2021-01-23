    var x = from c in db.Customers
                join o in db.Orders on c.UserID equals o.UserID into oo
                from o in oo.DefaultIfEmpty()
                group new { c, o } by c.UserID into g
                select new {
                    Customer = g.FirstOrDefault().c,
                    Total = g.Sum(x => x.o.Total)
                    Count = g.Select(x => x.o.OrderId).Distinct().Count()
                };
