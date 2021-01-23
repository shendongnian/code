    var firstQuery = (from r in db.SomeProcedure(Id)
                       select new MyClass
                       {
                            Id = r.Id,
                            Name = r.Name,
                            Company= r.Company,
                            Title = r.Title
                       }).ToList();
        var secondQuery = (from d in firstQuery
                          group d by d.Title into groupedTitles
                         select new MyClass2
                         {                                 
                             Title = groupedTitles.Key,  //How To include the Id                                  
                         });
          List<MyClass> mClass = firstQuery;
          List<MyClass2> mClass2 = secondQuery.ToList();
