    var query = (from c1 in db.ChildTable1
                 join c2 in db.ChildTable2 on c1.MasterId equals c2.MasterId
                 let t1 = db.ChildTable1.Where(x => value.Contains(x.ExtraId)).GroupBy(x => x.MasterId).Select(x => x.Max(y => y.ChildId1))
                 let t2 = db.ChildTable2.GroupBy(x => x.MasterId).Select(x => x.Max(y => y.ChildId2))
                 where t1.Contains(c1.ChildId1) && t2.Contains(c2.ChildId2)
                 
                 select new
                 {
                     c1.ChildId1,
                     c1.MasterTable.Info,
                     c1.Info1,
                     c2.Info2,
                     c1.LookupTable1.Description1,
                     c2.LookupTable2.Description2,
                     c2.LookupTable2.Description3
                 }).ToList();
