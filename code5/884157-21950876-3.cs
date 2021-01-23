     var set = new HashSet<Combination>(new CombinationComparer());
     var invalid = list.Aggregate(new List<Combination>(list.Count),
                                  (a,c) => 
                                  {
                                     if (!set.Add(c))
                                     {
                                         a.Add(c);
                                     }
                                     return a;
                                  });
