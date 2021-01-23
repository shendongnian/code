    var result = from b in db.DepositHistories
                 join a in db.Contracts on b.CotractID equals a.ID
                 join c in db.LearningPackages on a.LearningPackageID equals c.ID
                 group b by new{ a.ID,c.COntractValue} into g
                 where g.Sum(x=>x.Value) < g.Key.COntractValue 
                 || g.Sum(x=>x.Value) == null 
                 || g.Sum(x=>x.Value) == 0
                select new 
                      { 
                       ID = g.Key.ID, 
                       Value = g.Sum(x=>x.Value), 
                       ContractValue = g.Key.COntractValue
                      };
