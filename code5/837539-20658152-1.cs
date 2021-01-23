     var result = from t1 in db.Table1
                         let t2 = from q in db.Table2
                                  group q by q.ID into g
                                  select new
                                  {
                                      ID = g.Min(i => i.ID),
                                      Amount = g.Sum(i => i.Amount)
                                  }
                         select new
                         {
                             t1.ID,
                             t1.Name,
                             PaidAmount = t2.Where(s => s.ID == t1.ID).FirstOrDefault().Amount,
    
                         };
    
            foreach (var res in result.ToList())
            {
                Table1 t = (from t1 in db.Table1
                            where t1.ID == res.ID
                            select t1).Single();
                t.PaidAmount = res.PaidAmount;
                db.SaveChanges();
            }
