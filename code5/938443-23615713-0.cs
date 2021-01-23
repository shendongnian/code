    var resultList = configDB.Table2
                            .Where(x => x.DateTime > begDate && x.DateTime < endDate)
                            .GroupJoin(configDB.Table1,
                                        t2 => t2.AccountId,
                                        t1 => t1.Id,
                                        (t2, joined) => new { Description =  joined.Select(t=>t.Description).FirstOrDefault(), 
                                                              AccountId = t2.AccountId, 
                                                              Charges = joined.Count()})
                            .OrderByDescending(n => n.Charges)
                            .ToList();
