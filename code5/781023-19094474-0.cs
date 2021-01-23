    Country.SelectMany(x => x.Companies
                             .Select(y => new { 
                                                x.Name,
                                                x.CountryCode,
                                                y.ComapnyName,
                                                y.Address1,
                                                y.Address2,
                                                y.Owner
                                              } )).CopyToDataTable();
