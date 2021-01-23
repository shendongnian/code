    var resultList = configDB.Table2
                            .Where(x => x.DateTime > begDate && x.DateTime < endDate)
                            .GroupJoin(configDB.Table1,
                                        t2 => t2.AccountId,
                                        t1 => t1.Id,
                                        (t2, joined) => new
                                        {
                                            Description = joined.Select(t => t.Description).FirstOrDefault(),
                                            AccountID = t2.AccountId,
                                        })
                            .GroupBy(x => x.AccountID)
                            .Select(g => new
                            {
                                Account = g.Key, 
                                Charges = g.Count(), 
                                Description = g.Select(d=>d.Description).FirstOrDefault()
                            })
                            .OrderByDescending(g => g.Charges)
                            .ToList(); 
