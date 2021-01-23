    var query = repository.Members
                          .OrderByDescending(m => 
                                             m.Entry
                                              .Where(e =>
                                                     e.TimeStamp.Day <= timeComparison))
                                              .Count());
