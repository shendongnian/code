    WorkingDaysPrinter p = (d1, d2) => Enumerable.Range(0, d2.Subtract(d1).Days)
                                                 .Select(x => d1.AddDays(x))
                                                 .Where((x, i) => i == 0 || x.DayOfWeek != DayOfWeek.Sunday)
                                                 .ToList()
                                                 .ForEach(x =>
                                                  {
                                                      if (x.DayOfWeek == DayOfWeek.Saturday)
                                                          Console.WriteLine();
                                                      else
                                                          Console.Write(x.Day + " ");
                                                  });
