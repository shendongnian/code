    Country.SelectMany(x => (x.Companies ?? Enumerable.Empty<Company>())
                             .Select(y => new { 
                                                x.Name,
                                                x.CountryCode,
                                                y.ComapnyName,
                                                y.Address1,
                                                y.Address2,
                                                y.Owner
                                              } )).CopyToDataTable();
