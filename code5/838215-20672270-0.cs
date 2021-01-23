    var query = (from r in
                     (from c1 in db.ChildTable1
                      where db.ChildTable1.Where(x => value.Contains(x.ExtraId)).GroupBy(x => x.MasterId).Select(x => x.Max(y => y.ChildId1)).Contains(c1.ChildId1)
                      select c1)
                 let r2 = db.LookupTable2.Where(x => x.LookupId2 == r.MasterTable.ChildTable2.OrderByDescending(y => y.ChildId2).FirstOrDefault().LookupId2).FirstOrDefault()
                 select new
                   {
                       r.ChildId1,
                       r.Info1,
                       r.MasterTable.Info,
                       r.LookupTable1.Description1,
                       r2.Description2,
                       r2.Description3
                   }).ToList();
