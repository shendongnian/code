        counters = counters.Select(c =>
                                       {
                                           var delta = deltas.SingleOrDefault(d => d.Id == c.Id);
                                           return new Counter
                                                      {
                                                          Id = c.Id,
                                                          A = c.A + (delta != null ? delta.ADelta : 0),
                                                          B = c.B + (delta != null ? delta.BDelta : 0)
                                                      };
                                       }).ToList();
