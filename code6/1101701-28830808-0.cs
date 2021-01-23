    var result = from v in db.Vouchers
                 group v by v.Voucher_Date into g
                 select new
                     {
                      Date = g.Key,
                      Sale = g.Where(x=>x.Voucher_Type == "sale").Sum(y=y.Total),
                      Purchase = g.Where(x=>x.Voucher_Type == "purchase").Sum(x=>x.Total)
                     }
