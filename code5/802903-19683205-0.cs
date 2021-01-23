    var result = data.GroupBy(x => x.Tape)
                     .Select(g => {
                                   var maxItem = g.OrderByDescending(x => x.Count)
                                                  .FirstOrDefault();
                                   return new { 
                                        Tape = x.Key, 
                                        maxItem.Mask, 
                                        maxItem.Count 
                                      }
                                  });
