    var results = vendorsForPages.GroupBy(v => v.PricePage)
                                 .ToDictionary(g => g.Key,
                                               g => g.Select(x => x.VendorID)
                                                     .Distinct()
                                                     .Count());
