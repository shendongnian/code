    GetWorkingDays d = (d1, d2) => Enumerable.Range(0, d2.Subtract(d1).Days)
                                             .Select(x => d1.AddDays(x))
                                             .Where((x, i) => x.DayOfWeek != DayOfWeek.Sunday || i == 0)
                                             .ToList()
                                             .ForEach(x =>
                                              {
                                                  if (x.DayOfWeek == DayOfWeek.Saturday)
                                                      Console.WriteLine();
                                                  else
                                                      Console.Write(x.Day + " ");
                                              });
