    var data = (from o in ObjectContext.MyTable.Where(d => d.a == a)
                              select new MyObject
                              {
                                  Id = o.Id,
                                  StringProperty = SqlFunctions.StringConvert((double)o.intColumn)
                              });
