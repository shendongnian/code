    var result = Logs.Select(x=>x.Robot)
                     .GroupJoin(Logs, x=>x, x=>x.Robot, (x,y) => y)
                     .Where(x=>x.Any())
                     .Select(x=> 
                               var c = x.Count();
                               return 
                               new {
                                    x[0].Robot,
                                    x[0].Date,
                                    Task1 = x[0].State,
                                    Task2 = c > 1 ? x[1].State : "",
                                    Task4 = c > 2 ? x[2].State : ""
                                  });
