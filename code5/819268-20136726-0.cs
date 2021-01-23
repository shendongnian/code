    var costPageVendorsCount = vendorsForPages.GroupBy(v => v.PricePage)
                                              .ToDictionary(g => g.Key, 
                                                            g => g.GroupBy(gg => gg.VendorID)
                                                                  .Count()
                                                           );
