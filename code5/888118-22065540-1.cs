    var data = (from o in ObjectContext.MyTable.AsEnumerable().Where(d => d.a == a)
                                  select new MyObject
                                  {
                                      Id = o.Id,
                                      StringProperty = o.intColumn.ToString()
                                  });
