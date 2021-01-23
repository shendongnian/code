    var items = from item1 in db.Table1
                select new 
                {
                    Id = table1.Id,
                    Name = table1.Name,
                    Items = db.Table3
                              .Where(x => db.Table2
                                    .Where(t2 => t2.fkId == item1.fkId)
                                    .Select(t2 => t2.fkAid)
                              .Contains(x.Id)).ToList()
                };
