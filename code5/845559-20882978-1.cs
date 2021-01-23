    var result = myTable.AsEnumerable().Select(r =>
                         new {
                             Price1 = r.Price1,
                             Price2 = r.Price2,
                             Price3 = r.Price3,
                             Price4 = r.Price4,
                             ColSum = r.Price1 + r.Price2 + r.Price3 + r.Price4
                         });
      
