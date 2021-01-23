    var result = Logs.Select(x=>x.Robot)
                     .GroupJoin(Logs, x=>x, x=>x.Robot, (x,y) => y)
                     .Where(x=>x.Any())
                     .Select(x=> { 
                                   var c = x.Count();
                                   var a = x.ToList();
                                   return 
                                   new {
                                        a[0].Robot,
                                        a[0].Date,
                                        Task1 = a[0].State,
                                        Task2 = c > 1 ? a[1].State : "",
                                        Task4 = c > 2 ? a[2].State : ""
                                       };
                                 });
