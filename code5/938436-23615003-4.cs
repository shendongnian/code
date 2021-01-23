    var results = repository.Members
                            .OrderByDescending(m => 
                                               m.Entry
                                                .Where(e =>
                                                       e.TimeStamp.Date >= DateTime.Now.Date.AddDays(-30))
                                                .Count())
                            .Select(m => new {
                                MemberId = m.Id,
                                Count = m.Entry.Where(e => 
                                                      e.TimeStamp.Date >= DateTime.Now.Date.AddDays(-30))
                                               .Count()
                            });
