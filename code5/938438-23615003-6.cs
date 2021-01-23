    var results = repository.Members
                            .OrderByDescending(m => 
                                               m.Entry
                                                .Where(e =>
                                                       e.TimeStamp.Day <= timeComparison)
                                                .Count())
                            .Select(m => new {
                                MemberId = m.Id,
                                Count = m.Entry.Where(e => 
                                                      e.TimeStamp.Day <= timeComparison)
                                               .Count()
                            });
