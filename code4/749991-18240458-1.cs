    var result = Logs.Select(x=>x.Robot)
                     .GroupJoin(Logs, x=>x, x=>x.Robot, (x,y) => y)
                     .Select(x=> new {
                                    x[0].Robot,
                                    x[0].Date,
                                    Task1 = x[0].State,
                                    Task2 = x[1].State,
                                    Task4 = x[2].State
                                  });
