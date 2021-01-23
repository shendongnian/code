    var query = repository.Members
                          .OrderByDescending(m => 
                                             m.Entry
                                              .Where(e =>
                                                     e.TimeStamp.Date >= DateTime.Now.Date.AddDays(-30))
                                              .Count());
