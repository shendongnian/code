    var Result = Contracts.GroupJoin(DepositHistories, 
                                        a => a.ID, 
                                        b => b.CotractID, 
                                        (a, b) => new { a = a, b = b })
                                      .Join(LearningPackages, 
                                      a => a.a.LearningPackageID, 
                                      b => b.ID, 
                                      (a, b) => new { a = a, b = b })
                                      .GroupBy(e => new 
                                                        { 
                                                            e.a.a.ID, 
                                                            e.b.COntractValue 
                                                        }, 
                                                        (k, g) => new 
                                                                    { 
                                                                        ID = k.ID, 
                                                                        ContractValue = k.COntractValue, 
                                                                        Value =  g.Sum(x => x == null ? 0 : x.a.b.Sum(d=>d.Value)) 
                                                                    }
                                                ).Where(x => x.Value < x.ContractValue || x.Value == 0).ToList();
