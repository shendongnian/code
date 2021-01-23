    List<std> lstCustomWebsiteVerifiedIndex = StudIds.Select(r=> new std
                                                {
                                                  Id = r.Id, 
                                                  Name = r.Name, 
                                                  Value = r.Value,
                                                })
                                               .ToList();
