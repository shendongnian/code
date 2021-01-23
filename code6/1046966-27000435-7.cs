    string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
                foreach (var item in result)
                {
                    Console.WriteLine("Week:{0}\tEmployeeId:{1}", item.Week, item.IdEmployee);
                    foreach (var x in item.output.Select((v,i) => new {v,i}))
                    {
                        Console.WriteLine("{0}\t{1}",days[x.i],x.v.Amount);
                    }
                    Console.WriteLine();
                }
