    var result = Logs.GroupBy(x=> new {x.Robot, x.Date})                     
                     .Select(g=> {
                                   var a = g.ToList();
                                   return
                                   new {
                                     a[0].Robot,
                                     a[0].Date,
                                     Task1 = a[0].State,
                                     Task2 = a[1].State,
                                     Task4 = a[2].State
                                   };
                                 });
