    var result = Logs.Select(x=>x.Robot)
                     .GroupJoin(Logs, x=>x, x=>x.Robot, (x,y) => y)
                     .Select(x=> {
                                   var a = x.ToList();
                                   return
                                   new {
                                     a[0].Robot,
                                     a[0].Date,
                                     Task1 = a[0].State,
                                     Task2 = a[1].State,
                                     Task4 = a[2].State
                                   };
                                 });
