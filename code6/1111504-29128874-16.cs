    var query = (from x in db.MyClasses
                 select new
                     {
                         x.ID,
                         x.FullName,
                         Count1 = x.CountMyInnerClass(),
                         Count2 = x.CountMyInnerClassPlus(5),
                         Count3 = x.CountMyInnerClassProperty,
                         Count4 = LocalCountMyInnerClassPlus(x, 10),
                     }).AsExpandable2().ToList();
